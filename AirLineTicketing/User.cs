using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLineTicketing
{
    public class User
    {
        private String username;
        private String password;
        private String firstname;
        private String lastname;
        private String email;
        private String dob;
        private int id;

        public User(String username, String password, String firstname, String lastname, String email, String dob) {
            this.username = username;
            this.password = password;
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.dob = dob;
            this.id = 0;
        }

        public String getUsername() { return username; }
        public String getPassword() { return password; }
        public String getFirstname() { return firstname;}
        public String getLastname() { return lastname;}
        public String getEmail() { return email; }
        public String getDob() {  return dob; }
        public int getId() { return id; }
        public void setUsername(String username) {  this.username = username; }
        public void setPassword(String password) {  this.password = password; }
        public void setFirstname(String firstname) { this.firstname = firstname; }
        public void setLastname(String lastname) { this.lastname = lastname; }
        public void setEmail(String email) { this.email = email; }
        public void setDob(String dob) { this.dob = dob; }
        public void setId(int id) { this.id = id;  }
    }
}
