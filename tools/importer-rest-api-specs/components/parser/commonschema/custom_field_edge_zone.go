// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	"strings"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
)

var _ customFieldMatcher = edgeZoneFieldMatcher{}

type edgeZoneFieldMatcher struct {
}

func (e edgeZoneFieldMatcher) ReplacementObjectDefinition() sdkModels.SDKObjectDefinition {
	return sdkModels.SDKObjectDefinition{
		Type: sdkModels.EdgeZoneSDKObjectDefinitionType,
	}
}

func (e edgeZoneFieldMatcher) IsMatch(field sdkModels.SDKField, known internal.ParseResult) bool {
	if field.ObjectDefinition.Type != sdkModels.ReferenceSDKObjectDefinitionType {
		return false
	}

	// retrieve the model from the reference
	model, ok := known.Models[*field.ObjectDefinition.ReferenceName]
	if !ok {
		return false
	}

	hasName := false
	hasMatchingType := false

	for fieldName, fieldVal := range model.Fields {
		if strings.EqualFold(fieldName, "Name") {
			hasName = true
			continue
		}

		if strings.EqualFold(fieldName, "Type") {
			if fieldVal.ObjectDefinition.Type != sdkModels.ReferenceSDKObjectDefinitionType {
				continue
			}
			constant, ok := known.Constants[*fieldVal.ObjectDefinition.ReferenceName]
			if !ok || len(constant.Values) != 1 {
				continue
			}
			for k, v := range constant.Values {
				if strings.EqualFold(k, "EdgeZone") && strings.EqualFold(v, "EdgeZone") {
					hasMatchingType = true
				}
			}
			continue
		}

		// other fields
		return false
	}

	return hasName && hasMatchingType
}
