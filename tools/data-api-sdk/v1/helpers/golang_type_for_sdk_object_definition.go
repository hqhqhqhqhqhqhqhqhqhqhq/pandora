// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package helpers

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// GolangTypeForSDKObjectDefinition returns the Golang type name for the SDKObjectDefinition provided in `input`.
func GolangTypeForSDKObjectDefinition(input models.SDKObjectDefinition, golangPackageName *string, commonTypesPackageName *string) (*string, error) {
	// TODO: we should look to add unit tests for this method

	// NOTE: all of this validation should be done in the Importer and the API - this is purely sanity checking

	if input.Type == models.CSVSDKObjectDefinitionType {
		if input.NestedItem == nil {
			return nil, fmt.Errorf("a csv type must have a nested item but didn't get one")
		}

		// TODO: determine how to handle these
		// for now treat CSV's as a string
		return pointer.To("string"), nil
	}

	if input.Type == models.DictionarySDKObjectDefinitionType {
		if input.NestedItem == nil {
			return nil, fmt.Errorf("a dictionary type must have a nested item but didn't get one")
		}

		innerType, err := GolangTypeForSDKObjectDefinition(*input.NestedItem, golangPackageName, commonTypesPackageName)
		if err != nil {
			return nil, fmt.Errorf("determining inner type for dictionary: %+v", err)
		}

		return pointer.To(fmt.Sprintf("map[string]%s", *innerType)), nil
	}

	if input.Type == models.ListSDKObjectDefinitionType {
		if input.NestedItem == nil {
			return nil, fmt.Errorf("a list type must have a nested item but didn't get one")
		}

		innerType, err := GolangTypeForSDKObjectDefinition(*input.NestedItem, golangPackageName, commonTypesPackageName)
		if err != nil {
			return nil, fmt.Errorf("determining inner type for list: %+v", err)
		}

		return pointer.To(fmt.Sprintf("[]%s", *innerType)), nil
	}

	if input.Type == models.ReferenceSDKObjectDefinitionType {
		if input.ReferenceName == nil {
			return nil, fmt.Errorf("missing Reference for a Reference ObjectDefinition")
		}

		// Prepend a containing package name to the type where necessary
		out := *input.ReferenceName
		if golangPackageName != nil {
			out = fmt.Sprintf("%s.%s", *golangPackageName, out)
		} else if input.ReferenceNameIsCommonType != nil && *input.ReferenceNameIsCommonType && commonTypesPackageName != nil {
			out = fmt.Sprintf("%s.%s", *commonTypesPackageName, out)
		}

		return pointer.To(out), nil
	}

	if input.Nullable {
		nullableSdkObjectDefinitionTypesToValues := map[models.SDKObjectDefinitionType]string{
			// Simple Types
			models.BooleanSDKObjectDefinitionType:  "nullable.Type[bool]",
			models.DateTimeSDKObjectDefinitionType: "nullable.Type[string]", // intentional since we have cast methods one way or the other
			models.FloatSDKObjectDefinitionType:    "nullable.Type[float64]",
			models.IntegerSDKObjectDefinitionType:  "nullable.Type[int64]",
			models.StringSDKObjectDefinitionType:   "nullable.Type[string]",

			// Complex Types
			models.LocationSDKObjectDefinitionType: "nullable.Type[string]",
		}

		if v, ok := nullableSdkObjectDefinitionTypesToValues[input.Type]; ok {
			return pointer.To(v), nil
		}
	}

	sdkObjectDefinitionTypesToValues := map[models.SDKObjectDefinitionType]string{
		// Simple Types
		models.BooleanSDKObjectDefinitionType:  "bool",
		models.DateTimeSDKObjectDefinitionType: "string", // intentional since we have cast methods one way or the other
		models.FloatSDKObjectDefinitionType:    "float64",
		models.IntegerSDKObjectDefinitionType:  "int64",
		models.StringSDKObjectDefinitionType:   "string",

		// Complex Types
		models.LocationSDKObjectDefinitionType:  "string",
		models.RawFileSDKObjectDefinitionType:   "[]byte",
		models.RawObjectSDKObjectDefinitionType: "interface{}", // TODO: should we standardise this on `any`?
		models.TagsSDKObjectDefinitionType:      "map[string]string",

		// Common Schema Types
		models.EdgeZoneSDKObjectDefinitionType:                                "edgezones.Model",
		models.SystemAssignedIdentitySDKObjectDefinitionType:                  "identity.SystemAssigned",
		models.UserAssignedIdentityListSDKObjectDefinitionType:                "identity.UserAssignedList",
		models.UserAssignedIdentityMapSDKObjectDefinitionType:                 "identity.UserAssignedMap",
		models.LegacySystemAndUserAssignedIdentityListSDKObjectDefinitionType: "identity.LegacySystemAndUserAssignedList",
		models.LegacySystemAndUserAssignedIdentityMapSDKObjectDefinitionType:  "identity.LegacySystemAndUserAssignedMap",
		models.SystemAndUserAssignedIdentityListSDKObjectDefinitionType:       "identity.SystemAndUserAssignedList",
		models.SystemAndUserAssignedIdentityMapSDKObjectDefinitionType:        "identity.SystemAndUserAssignedMap",
		models.SystemOrUserAssignedIdentityListSDKObjectDefinitionType:        "identity.SystemOrUserAssignedList",
		models.SystemOrUserAssignedIdentityMapSDKObjectDefinitionType:         "identity.SystemOrUserAssignedMap",
		models.SystemDataSDKObjectDefinitionType:                              "systemdata.SystemData",
		models.ZoneSDKObjectDefinitionType:                                    "string",
		models.ZonesSDKObjectDefinitionType:                                   "zones.Schema",
	}
	if v, ok := sdkObjectDefinitionTypesToValues[input.Type]; ok {
		return pointer.To(v), nil
	}

	return nil, fmt.Errorf("unimplemented object definition type %q", string(input.Type))
}
