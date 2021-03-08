//
using System;

// 
public class User
{

    // variables/fields/attributes
    protected static int numUsers = 0;
    protected int id;
    protected string firstName;
    protected string lastName;

    // constructor
    public User()
    {
        // increment numUsers to get id for new user
        numUsers++;

        // 
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
        this.id = numUsers;

        // initialize first and last name to blank strings unless given in constructor
        this.firstName = first;
        this.lastName = last;

    }

    // methods/verbs
    public void printTotalUsers() { Console.WriteLine("Total Users: " + numUsers); }
    public void printUser() { Console.WriteLine("User ID: " + this.id + " with name: " + this.firstName + " " + this.lastName + "."); }

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