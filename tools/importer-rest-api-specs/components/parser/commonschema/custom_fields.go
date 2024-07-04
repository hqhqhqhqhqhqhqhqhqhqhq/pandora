// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commonschema

import (
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/internal"
)

type customFieldMatcher interface {
	// IsMatch returns whether the field and definition provided match this Custom Field Matcher
	// meaning that the types should be replaced with the CustomFieldType found in customFieldType
	IsMatch(field sdkModels.SDKField, known internal.ParseResult) bool

	// ReplacementObjectDefinition returns the replacement SDKObjectDefinition which should be used
	// in place of the parsed SDKObjectDefinition for this SDKField.
	ReplacementObjectDefinition() sdkModels.SDKObjectDefinition
}

var CustomFieldMatchers = []customFieldMatcher{
	edgeZoneFieldMatcher{},
	locationMatcher{},
	systemAssignedIdentityMatcher{},
	legacySystemAndUserAssignedIdentityListMatcher{},
	legacySystemAndUserAssignedIdentityMapMatcher{},
	systemAndUserAssignedIdentityListMatcher{},
	systemAndUserAssignedIdentityMapMatcher{},
	systemOrUserAssignedIdentityListMatcher{},
	systemOrUserAssignedIdentityMapMatcher{},
	tagsMatcher{},
	userAssignedIdentityListMatcher{},
	userAssignedIdentityMapMatcher{},
	systemDataMatcher{},
	zoneFieldMatcher{},
	zonesFieldMatcher{},
}
