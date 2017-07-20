/*--------------------------------------------------------------------------------------------------
 * Name:        Dan Cassidy
 * Date:        2015-06-02
 * Assignment:  cView-P1
 * Source File: CViewDataSet.cs
 * Class:       CSCI-C 490, C# Programming, MoWe 08:00
 * Purpose:     Builds a List-based class for collections of CViewData objects and contains related
 *              methods and properties.
--------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cView_P1_DanCassidy
{
    class CViewDataSet
    {
        //Basic property of the class.
        private List<CViewData> dataSet = new List<CViewData>();

        //Enable read-only access to the Count property.
        public int Count
        {
            get
            {
                return dataSet.Count;
            }
        }

        //Enable read-only access to the Header property. Uses the header from the CViewData class
        //so if needs to be changed, it only needs to be changed in one place.
        public string Header
        {
            get
            {
                return CViewData.Header;
            }
        }

        /*------------------------------------------------------------------------------------------
         * Method:  this[]
         * Purpose: Access the objects in this dataset via index number.
         * Input:   int objectNum, the index of the object that will be accessed.
         * Output:  CViewData object of the referenced object at the index.
        ------------------------------------------------------------------------------------------*/
        public CViewData this[int objectNum]
        {
            get
            {
                //Try to simply return the object at index objectNum.
                try
                {
                    return dataSet[objectNum];
                }
                catch (ArgumentOutOfRangeException)
                {
                    //If this exception is caught, let the user know and return a null.
                    Console.WriteLine("Index [{0}] is out of range.", objectNum);
                    return null;
                }
            }
            set
            {
                //Try to set the object at index objectNum.
                try
                {
                    dataSet[objectNum] = value;
                }
                catch (ArgumentOutOfRangeException)
                {
                    //If this exception is caught, do nothing further and let the user know.
                    Console.WriteLine("Index [{0}] is out of range.", objectNum);
                }
            }
        }

        /*------------------------------------------------------------------------------------------
         * Method:  Add
         * Purpose: Add a data object to the dataset.
         * Input:   CViewData toAdd, this is the object that will get added to the dataset.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        public void Add(CViewData toAdd)
        {
            //Add object using List Add method.
            dataSet.Add(toAdd);
        }

        /*------------------------------------------------------------------------------------------
         * Method:  Delete
         * Purpose: Delete an object at the given index from the dataset.
         * Input:   int indexToRemove, the index of the object to be removed from the dataset.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        public void Delete(int indexToRemove)
        {
            //Delete object at specified index by using List RemoveAt method.
            dataSet.RemoveAt(indexToRemove);
        }

        /*------------------------------------------------------------------------------------------
         * Method:  SortByName
         * Purpose: Sort the dataset by the Name property of the objects, with a secondary sort by
         *          the Address property.
         * Input:   Nothing.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        public void SortByName()
        {
            //Idea from Stack Overflow: http://stackoverflow.com/a/3309230
            //Yay lambda expressions!
            dataSet = dataSet.OrderBy(data => data.Name).OrderBy(data => data.Address).ToList();
        }

        /*------------------------------------------------------------------------------------------
         * Method:  Search
         * Purpose: Search for a given string in this dataset.
         * Input:   string toSearchFor, this is the string that will be searched for.
         * Output:  CViewDataSet object, containing all (if any) objects found.
        ------------------------------------------------------------------------------------------*/
        public CViewDataSet Search(string toSearchFor)
        {
            //Create a new dataset to hold the found objects.
            CViewDataSet foundDataSet = new CViewDataSet();

            //Iterate through the objects and add them to foundDataSet if applicable.
            foreach (CViewData data in dataSet)
                if (data.Contains(toSearchFor))
                    foundDataSet.Add(data);

            //Return the dataset containing the found objects.
            return foundDataSet;
        }

        /*------------------------------------------------------------------------------------------
         * Method:  ToString
         * Purpose: Override of the ToString() method. Formats the return value so it looks pretty.
         * Input:   Nothing.
         * Output:  String object containing serialized collection data.
        ------------------------------------------------------------------------------------------*/
        public override string ToString()
        {
            //Declare the string.
            string toReturn = "";

            //Build the string.
            foreach (CViewData item in dataSet)
                toReturn += item.ToString() + "\n";

            //Return the string.
            return toReturn;
        }
    }
}
