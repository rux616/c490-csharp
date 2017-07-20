using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ph3
{
    class ItemDB : IEnumerable
    {
        //Implements a counter for the ID number for Item objects. This is due to the fact that
        //ItemList.Count will become unreliable once objects are removed from the list.
        private static int CurrentItemID = 1;

        private List<Item> itemList = new List<Item>();

        /*------------------------------------------------------------------------------------------
         * Method:  
         * Purpose: 
         * Input:   
         * Output:  
        ------------------------------------------------------------------------------------------*/
        public void Add(Item item)
        {
            item.ItemID = CurrentItemID++;
            itemList.Add(item);
        }

        /*------------------------------------------------------------------------------------------
         * Method:  
         * Purpose: 
         * Input:   
         * Output:  
        ------------------------------------------------------------------------------------------*/
        public void PrintAll()
        {
            foreach (var item in itemList)
                Console.WriteLine(item);
        }

        /*------------------------------------------------------------------------------------------
         * Method:  
         * Purpose: 
         * Input:   
         * Output:  
        ------------------------------------------------------------------------------------------*/
        public override string ToString()
        {
            string toReturn = "";

            foreach (var item in itemList)
                toReturn += item.ToString() + "\n";

            return toReturn;
        }

        /*------------------------------------------------------------------------------------------
         * Method:  
         * Purpose: 
         * Input:   
         * Output:  
        ------------------------------------------------------------------------------------------*/
        public int Count { get { return itemList.Count; } }

        /*------------------------------------------------------------------------------------------
         * Method:  this[]
         * Purpose: Access the objects in this list via index number.
         * Input:   int index, the index number of the object to access.
         * Output:  Item object located at the specified index.
         * 
         * PROBABLY NEEDS TRY CATCH
        ------------------------------------------------------------------------------------------*/
        public Item this[int index] { get { return itemList[index]; } }

        /*------------------------------------------------------------------------------------------
         * Method:  
         * Purpose: 
         * Input:   
         * Output:  
        ------------------------------------------------------------------------------------------*/
        public void Delete(Item itemToDelete)
        {
            DeleteItemID(itemToDelete.ItemID);
        }

        /*------------------------------------------------------------------------------------------
         * Method:  
         * Purpose: 
         * Input:   
         * Output:  
        ------------------------------------------------------------------------------------------*/
        public void DeleteItemID(int itemIDToDelete)
        {
            Delete(itemList.FindIndex(i => i.ItemID == itemIDToDelete));
        }

        /*------------------------------------------------------------------------------------------
         * Method:  
         * Purpose: 
         * Input:   
         * Output:  
        ------------------------------------------------------------------------------------------*/
        public void Delete(int indexToRemove)
        {
            itemList.RemoveAt(indexToRemove);
        }

        /*------------------------------------------------------------------------------------------
         * Method:  
         * Purpose: 
         * Input:   
         * Output:  
        ------------------------------------------------------------------------------------------*/
        public ItemDB Search(object toSearchFor, string itemType, Item.Fields field)
        {
            var ignoreCase = StringComparison.OrdinalIgnoreCase;

            return new ItemDB() { itemList = this.itemList.FindAll(i => i.ItemType == itemType &&
                ((string)i[field]).IndexOf((string)toSearchFor, ignoreCase) >= 0) };
        }
        
        //Implementation for the GetEnumerator method. Source:
        //https://msdn.microsoft.com/en-us/library/system.collections.ienumerable(v=vs.110).aspx
        /*------------------------------------------------------------------------------------------
         * Method:  
         * Purpose: 
         * Input:   
         * Output:  
        ------------------------------------------------------------------------------------------*/
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }

        /*------------------------------------------------------------------------------------------
         * Method:  
         * Purpose: 
         * Input:   
         * Output:  
        ------------------------------------------------------------------------------------------*/
        public ItemDBEnum GetEnumerator()
        {
            return new ItemDBEnum(itemList);
        }
    }

    //Enumerator for the ItemDB class. Much help came from MSDN.
    //https://msdn.microsoft.com/en-us/library/system.collections.ienumerable(v=vs.110).aspx
    class ItemDBEnum : IEnumerator
    {
        private List<Item> itemList;

        int position = -1;

        /*------------------------------------------------------------------------------------------
         * Method:  
         * Purpose: 
         * Input:   
         * Output:  
        ------------------------------------------------------------------------------------------*/
        public ItemDBEnum(List<Item> list)
        {
            itemList = list;
        }

        /*------------------------------------------------------------------------------------------
         * Method:  
         * Purpose: 
         * Input:   
         * Output:  
        ------------------------------------------------------------------------------------------*/
        public bool MoveNext()
        {
            position++;
            return (position < itemList.Count);
        }

        /*------------------------------------------------------------------------------------------
        * Method:  
        * Purpose: 
        * Input:   
        * Output:  
       ------------------------------------------------------------------------------------------*/
        public void Reset()
        {
            position = -1;
        }

        /*------------------------------------------------------------------------------------------
         * Method:  
         * Purpose: 
         * Input:   
         * Output:  
        ------------------------------------------------------------------------------------------*/
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        /*------------------------------------------------------------------------------------------
         * Method:  
         * Purpose: 
         * Input:   
         * Output:  
        ------------------------------------------------------------------------------------------*/
        public Item Current
        {
            get
            {
                try
                {
                    return itemList[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
