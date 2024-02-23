// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourceids

import (
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ commonIdMatcher = commonIdProvisioningService{}

type commonIdProvisioningService struct{}

func (c commonIdProvisioningService) id() models.ResourceID {
	name := "ProvisioningService"
	return models.ResourceID{
		CommonIDAlias: &name,
		ConstantNames: []string{},
		Segments: []models.ResourceIDSegment{
			models.NewStaticValueResourceIDSegment("subscriptions", "subscriptions"),
			models.NewSubscriptionIDResourceIDSegment("subscriptionId"),
			models.NewStaticValueResourceIDSegment("resourceGroups", "resourceGroups"),
			models.NewResourceGroupNameResourceIDSegment("resourceGroupName"),
			models.NewStaticValueResourceIDSegment("providers", "providers"),
			models.NewResourceProviderResourceIDSegment("resourceProvider", "Microsoft.Devices"),
			models.NewStaticValueResourceIDSegment("provisioningServices", "provisioningServices"),
			models.NewUserSpecifiedResourceIDSegment("provisioningServiceName", "provisioningServiceName"),
		},
	}
}
