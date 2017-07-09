using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Emlak.Models
{
    public class Login:IDisposable
    {
        SqlConnection connection;



        [Required(ErrorMessage = "Email Id Required")]
        [DisplayName("Email ID")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", 
                                    ErrorMessage = "Email Format is wrong")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string EmailId
        {
            get; set;
        }
 
        [DataType(DataType.Password)]
        [Required(ErrorMessage="Password Required")]
        [DisplayName("Password")]
        [StringLength(30, ErrorMessage = ":Less than 30 characters")]
        public string Password
        {
            get;  set;
        }
 
        public bool IsUserExist(string email, string password)
        {
            bool flag = false;
            SqlConnection connection = new SqlConnection( 
    System.Configuration.ConfigurationManager.ConnectionStrings["DAL"].ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("select count(*) from Users where Email='" + email + "' and Password='" + password + "'", connection);
            flag = Convert.ToBoolean(command.ExecuteScalar());
            connection.Close();
            return flag;
        }

      
        public void Dispose()
        {
            if(connection != null && connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
      
    }
    public class Register
    {
        [Required(ErrorMessage = "FirstName Required:")]
        [DisplayName("First Name:")]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Special Characters not allowed")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName Required:")]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Special Characters not allowed")]
        [DisplayName("Last Name:")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Required:")]
        [DisplayName("Email:")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
                                                ErrorMessage = "Email Format is wrong")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required:")]
        [DataType(DataType.Password)]
        [DisplayName("Password:")]
        [StringLength(30, ErrorMessage = "Less than 30 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password Required:")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm not matched.")]
        [Display(Name = "Confirm password:")]
        [StringLength(30, ErrorMessage = "Less than 30 characters")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "City Required")]
        [DisplayName("City:")]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Special Characters not allowed")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "State Required")]
        [DisplayName("State:")]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Special Characters not allowed")]
        [StringLength(50, ErrorMessage = "Less than 50 characters")]
        public string State { get; set; }


        public bool IsUserExist(string email)
        {
            bool flag = false;
            SqlConnection connection = new  SqlConnection
    (System.Configuration.ConfigurationManager.ConnectionStrings["DAL"].ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("select count(*) from Users where Email='" + email + "'", connection);
            flag = Convert.ToBoolean(command.ExecuteScalar());
            connection.Close();
            return flag;
        }
          public bool Insert()
        {
            bool flag = false;
            if (!IsUserExist(Email))
            {
                SqlConnection connection = new SqlConnection
    (System.Configuration.ConfigurationManager.ConnectionStrings["DAL"].ConnectionString);
                connection.Open();
                SqlCommand command = new SqlCommand("insert into Users values('" +
                Email + "','" + FirstName + "','" +LastName +"','" + Password + "', '" + City + "','" + State + "')", connection);
                flag = Convert.ToBoolean(command.ExecuteNonQuery());
                connection.Close();
                return flag;
            }
            return flag;
        }
    }
}