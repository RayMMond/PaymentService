﻿using EasyAbp.PaymentService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EasyAbp.PaymentService.Authorization
{
    public class PaymentServicePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var moduleGroup = context.AddGroup(PaymentServicePermissions.GroupName, L("Permission:PaymentService"));
            
            var payment = moduleGroup.AddPermission(PaymentServicePermissions.Payments.Default, L("Permission:Payment"));
            payment.AddChild(PaymentServicePermissions.Payments.Manage, L("Permission:Manage"));
            payment.AddChild(PaymentServicePermissions.Payments.CrossStore, L("Permission:CrossStore"));
            payment.AddChild(PaymentServicePermissions.Payments.Create, L("Permission:Create"));
            
            var refund = moduleGroup.AddPermission(PaymentServicePermissions.Refunds.Default, L("Permission:Refund"));
            refund.AddChild(PaymentServicePermissions.Refunds.Manage, L("Permission:Manage"));
            refund.AddChild(PaymentServicePermissions.Refunds.CrossStore, L("Permission:CrossStore"));
            refund.AddChild(PaymentServicePermissions.Refunds.Create, L("Permission:Create"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<PaymentServiceResource>(name);
        }
    }
}