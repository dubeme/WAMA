﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WAMA.Core.Models.DTOs;
using WAMA.Core.ViewModel.User;

namespace WAMA.Web.Model
{
    public class UserAccountViewModelBinder : IModelBinder
    {
        private static Type UserAccountViewModelType = typeof(UserAccountViewModel);
        private const string USER_ACCOUNT_TYPE_NAME = nameof(UserAccountViewModel.AccountType);

        private readonly IEnumerable<string> NamesOfRequiredFields = UserAccountViewModelType.GetProperties()
                    .Where(property => property.GetCustomAttribute<RequiredAttribute>() != null)
                    .Select(property => property.Name);

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            await Task.Delay(0);

            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            if (Equals(UserAccountViewModelType, bindingContext.ModelType))
            {
                var namesOfMissingRequiredProperties = NamesOfRequiredFields.Except(
                    bindingContext.HttpContext.Request.Form.Select(field => field.Key));

                if (namesOfMissingRequiredProperties.Any())
                {
                    foreach (var missingPropertyName in namesOfMissingRequiredProperties)
                    {
                        bindingContext.ModelState.AddModelError($"{missingPropertyName}",
                            $"Missing required property, ({missingPropertyName}).");
                    }
                }

                var formFieldsExcludingUserAccountType = bindingContext.HttpContext.Request.Form
                    .Where(formEntry => !Equals(formEntry.Key, USER_ACCOUNT_TYPE_NAME));

                var accountType = bindingContext.ValueProvider
                    .GetValue(USER_ACCOUNT_TYPE_NAME)
                    .ConvertTo<UserAccountType>();

                var user = InstantiateUserAccountViewModel(accountType);

                foreach (var item in formFieldsExcludingUserAccountType)
                {
                    var property = UserAccountViewModelType.GetProperty(item.Key,
                        BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                    if (Equals(property, null) == false)
                    {
                        var convertedValue = Convert(item.Value.FirstOrDefault(), property.PropertyType);

                        property.SetValue(user, convertedValue);
                    }
                }

                bindingContext.Model = user;
                bindingContext.Result = ModelBindingResult.Success(user);
            }
        }

        private static UserAccountViewModel InstantiateUserAccountViewModel(UserAccountType accountType)
        {
            switch (accountType)
            {
                case UserAccountType.Patron:
                    return new PatronUserAccountViewModel();

                case UserAccountType.Employee:
                    return new EmployeeUserAccountViewModel();

                case UserAccountType.Manager:
                    return new ManagerUserAccountViewModel();

                case UserAccountType.Administrator:
                    return new AdministratorUserAccountViewModel();

                case UserAccountType.Mantainance:
                    return new MantainanceUserAccountViewModel();

                default:
                    throw new InvalidOperationException($"{accountType} isn't known");
            }
        }

        private static object Convert(object source, Type destinationType)
        {
            if (destinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }

            var typeInfo = destinationType.GetTypeInfo();

            if (typeInfo.IsGenericType &&
                destinationType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (source == null)
                {
                    return null;
                }
                destinationType = Nullable.GetUnderlyingType(destinationType);
            }

            if (typeInfo.IsEnum)
                return Enum.Parse(destinationType, $"{source}");

            return System.Convert.ChangeType(source, destinationType);
        }
    }
}