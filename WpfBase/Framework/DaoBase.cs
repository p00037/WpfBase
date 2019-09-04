using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WpfBase.Models;
using static WpfBase.Common.ComEnum;
using static WpfBase.Common.DB;

namespace WpfBase.Framework
{
    public class DaoBase
    {
        protected AppDbContext context = CreateAppDbContext();

        protected EntityState ConvertEnmEditModeToEntityState(EnmEditMode editMode)
        {
            switch (editMode)
            {
                case EnmEditMode.Insert:
                    return EntityState.Added;
                case EnmEditMode.Update:
                    return EntityState.Modified;
                case EnmEditMode.Delete:
                    return EntityState.Deleted;
                default:
                    return EntityState.Added;
            }
        }

        protected List<string> GetErrorMessageEntityValidation<T>(T data) where T : new()
        {
            var errorMessages = new List<string>();

            var validationContext = new ValidationContext(data);
            var validationResults = new List<ValidationResult>();
            if (Validator.TryValidateObject(data, validationContext, validationResults, true) == false)
            {
                errorMessages.AddRange(validationResults.Select(x => x.ErrorMessage));
            }

            return errorMessages;
        }
    }
}
