//
using System;

// 
public class User
{

    // variables/fields/attributes
    protected static int numUsers = 0;
    //public int ID;
    //public string FIRSTNAME = "Unknown";
    //public string UserName = "Unknownn";
    protected int id;
    protected string firstName;
    protected string lastName;

    // constructor
    public User()
    {
        // increment numUsers to get id for new user
        numUsers++;

        // 
        //this.ID = 0;
        this.id = numUsers;

        // initialize first and last name to blank strings unless given in constructor
        firstName = "";
        lastName = "";
    }

    // overloaded constructor
    public User(string first, string last)
    {

        // increment numUsers to get id for new user
        numUsers++;

        // 
        //this.ID = 0;
        this.id = numUsers;

        // initialize first and last name to blank strings unless given in constructor
        this.firstName = first;
        this.lastName = last;

        //this.ID = start;
        //this.FIRSTNAME = FIRSTNAME;
        //numUsers++;
    }

    // methods/verbs
    public void printTotalUsers() { Console.WriteLine("Total Users: " + numUsers); }
    public void printUser() { Console.WriteLine("User ID: " + this.id + " with name: " + this.firstName + " " + this.lastName + "."); }
    //public void eat() { Console.WriteLine("User of FIRSTNAME " + this.FIRSTNAME + " with name " + this.UserName + " is eating."); }
    //public void sleep() { Console.WriteLine("User of FIRSTNAME " + this.FIRSTNAME + " with name " + this.UserName + " is sleeping."); }


    // properties (get, set)
    public int ID
    {
        get { return id; } // read
        set { id = value; } // write
    }

    public string FIRSTNAME
    {
        get { return firstName; } // read
        set { firstName = value; } // write
    }

    public string LASTNAME
    {
        get { return lastName; } // read
        set { lastName = value; } // write
    }
}