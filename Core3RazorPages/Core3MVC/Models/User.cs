using Core3MVC.Data;
using FluentValidation.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Core3MVC.Models
{
    public class UserInputValidator<TElement> : PropertyValidator
    {
        private readonly ApplicationDbContext _context;
        public UserInputValidator(ApplicationDbContext context)
            : base("{Message}.")
        {
            _context = context;
        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            var id = (int)context.PropertyValue;
            

            // ..... 

            return true;
        }
        protected async override Task<bool> IsValidAsync(PropertyValidatorContext context, CancellationToken cancellation)
        {
            var ms = await _context.Student.ToListAsync();
            return true;
        }
    }
    //public class User
    //{
    //    public int Id { get; set; }
    //    public List<PropertyOwner> PropertyOwners { get;set; }
    //}

    //public class PropertyOwner
    //{
    //    public MyProperty Property { get; set; }
    //    public Owner Owner { get; set; }
    //}

    //public class Owner
    //{
    //}

    //public class MyProperty
    //{
    //    public List<PropertyTenantLeas> PropertyTenantLeases { get; set; }
    //}

    //public class PropertyTenantLeas
    //{
    //}

    //public class UserViewModel 
    //{ 

    //}

}
