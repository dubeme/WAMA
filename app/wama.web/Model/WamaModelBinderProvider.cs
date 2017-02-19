using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using WAMA.Core.ViewModel.User;

namespace WAMA.Web.Model
{
    public class WamaModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (Equals(typeof(UserAccountViewModel), context.Metadata.ModelType))
            {
                return new UserAccountViewModelBinder();
            }

            return null;
        }
    }
}