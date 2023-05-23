using LaNacionChallenge.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.RegularExpressions;

namespace LaNacionChallenge.Helpers
{
    public static class ValidationsHelper
    {
        public static void ValidateModel(ModelStateDictionary ModelState, Contact contact)
        {
            if (string.IsNullOrEmpty(contact.Name))
            {
                ModelState.AddModelError("Name", "El nombre no puede estar vacío");
            }

            if (!string.IsNullOrEmpty(contact.Email))
            {
                string format = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

                if (!Regex.IsMatch(contact.Email, format))
                {
                    ModelState.AddModelError("Email", "El correo electrónico no contiene un formato válido (usuario@ejemplo.com)");
                }
            }
            else
            {
                ModelState.AddModelError("Email", "El correo electrónico no puede estar vacío");
            }
        }
    }
}
