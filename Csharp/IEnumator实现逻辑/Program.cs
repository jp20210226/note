using System;
using System.Collections;
namespace IEnumator实现逻辑
{
    #region MyRegion


    //// Simple business object.
    //public class Person
    //{
    //    public Person(string fName, string lName)
    //    {
    //        this.firstName = fName;
    //        this.lastName = lName;
    //    }

    //    public string firstName;
    //    public string lastName;
    //}

    //// Collection of Person objects. This class
    //// implements IEnumerable so that it can be used
    //// with ForEach syntax.
    //public class People : IEnumerable
    //{
    //    private Person[] _people;
    //    public People(Person[] pArray)
    //    {
    //        _people = new Person[pArray.Length];

    //        for (int i = 0; i < pArray.Length; i++)
    //        {
    //            _people[i] = pArray[i];
    //        }
    //    }

    //    // Implementation for the GetEnumerator method.
    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return (IEnumerator)GetEnumerator();
    //    }

    //    public PeopleEnum GetEnumerator()
    //    {
    //        return new PeopleEnum(_people);
    //    }
    //}
    #endregion

    #region When you implement IEnumerable, you must also implement IEnumerator.
    //// When you implement IEnumerable, you must also implement IEnumerator.
    //public class PeopleEnum : IEnumerator
    //{
    //    public Person[] _people;

    //    // Enumerators are positioned before the first element
    //    // until the first MoveNext() call.
    //    int position = -1;

    //    public PeopleEnum(Person[] list)
    //    {
    //        _people = list;
    //    }

    //    public bool MoveNext()
    //    {
    //        position++;
    //        return (position < _people.Length);
    //    }

    //    public void Reset()
    //    {
    //        position = -1;
    //    }

    //    object IEnumerator.Current
    //    {
    //        get
    //        {
    //            return Current;
    //        }
    //    }

    //    public Person Current
    //    {
    //        get
    //        {
    //            try
    //            {
    //                return _people[position];
    //            }
    //            catch (IndexOutOfRangeException)
    //            {
    //                throw new InvalidOperationException();
    //            }
    //        }
    //    }
    //}

    //class App
    //{
    //    static void Main()
    //    {
    //        Person[] peopleArray = new Person[3]
    //        {
    //        new Person("John", "Smith"),
    //        new Person("Jim", "Johnson"),
    //        new Person("Sue", "Rabon"),
    //        };

    //        People peopleList = new People(peopleArray);
    //        foreach (Person p in peopleList)
    //            Console.WriteLine(p.firstName + " " + p.lastName);

    //    }
    //}

    /* This code produces output similar to the following:
     *
     * John Smith
     * Jim Johnson
     * Sue Rabon
     *
     */
    #endregion


    public class Program
    {
        static void Main()
        {
            Person[] peopleArray = new Person[3]
            {
            new Person("John", "Smith"),
            new Person("Jim", "Johnson"),
            new Person("Sue", "Rabon"),
            };

            People peopleList = new People(peopleArray);
            foreach (Person p in peopleList)
                Console.WriteLine(p.firstName + " " + p.lastName);

        }
    }

    public struct Person
    {
        public Person(string fName, string lName)
        {
            this.firstName = fName;
            this.lastName = lName;
        }
        public string firstName;
        public string lastName;


    }
    public class People : IEnumerable
    {
        private Person[] _people;

        public People(Person[] PArray)
        {
            _people = new Person[PArray.Length];
            for (int i = 0; i < PArray.Length; i++)
            {
                _people[i] = PArray[i];
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public PeopleEnum GetEnumerator()
        {
            return new PeopleEnum(_people);
        }
    }

    public class PeopleEnum : IEnumerator
    {
        public Person[] _people;
        public PeopleEnum(Person[] _list)
        {
            _people = _list;
        }
        int postion = -1;



        public bool MoveNext()
        {
            postion++;
            return (postion < _people.Length);
        }

        public void Reset()
        {
            postion = -1;
        }

        //public object Current => throw new NotImplementedException();
        object IEnumerator.Current
        {
            get { return Current; }
        }
        public Person Current
        {
            get
            {
                try
                { return _people[postion]; }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }

            }
        }
    }
}
