/*--------------------------------------------------------------------------------------------------
 * Author:      Dan Cassidy and Dr. Raman Adaikkalavan
 * Date:        2015-06-17
 * Assignment:  cView-P3
 * Source File: ItemDB.cs
 * Language:    C#
 * Course:      CSCI-C 490, C# Programming, MoWe 08:00
 * Purpose:     Encapsulates a List-based collection of Item objects and contains related methods
 *              and properties.
--------------------------------------------------------------------------------------------------*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ph3
{
    public class ItemDB : IEnumerable
    {
        /*------------------------------------------------------------------------------------------
         * Name:    KeyStart
         * Type:    Constant
         * Purpose: Contains the default value for currentItemKey.
        ------------------------------------------------------------------------------------------*/
        private const int KeyStart = 1;

        /*------------------------------------------------------------------------------------------
         * Name:    currentItemKey
         * Type:    Field
         * Purpose: Implements a counter for the ID number for Item objects. This is due to the fact
         *          that itemList.Count becomes unreliable if objects are removed from the list.
        ------------------------------------------------------------------------------------------*/
        private static int currentItemKey = KeyStart;

        /*------------------------------------------------------------------------------------------
         * Name:    itemList
         * Type:    Field
         * Purpose: List of Item objects.
        ------------------------------------------------------------------------------------------*/
        private List<Item> itemList = new List<Item>();

        /*------------------------------------------------------------------------------------------
         * Name:    Count
         * Type:    Property
         * Purpose: Enable access to the Count property of itemList.
        ------------------------------------------------------------------------------------------*/
        public int Count { get { return itemList.Count; } }

        /*------------------------------------------------------------------------------------------
         * Name:    IsChanged
         * Type:    Property
         * Purpose: Flag that determines whether the itemDB has been modified (true) or not (false).
        ------------------------------------------------------------------------------------------*/
        public bool IsChanged { get; private set; }

        /*------------------------------------------------------------------------------------------
         * Name:    Add
         * Type:    Method
         * Purpose: Add the specified item object to the ItemDB object.
         * Input:   Item item, specifies the item to be added to the ItemDB object.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        public void Add(Item item)
        {
            // Set the item ID to whatever the current key is, increment the key, then add the item.
            item.ItemID = currentItemKey++;
            itemList.Add(item);
            IsChanged = true;
        }

        /*------------------------------------------------------------------------------------------
         * Name:    Delete
         * Type:    Method
         * Purpose: Attempt to delete the Item with the the specified ItemID.
         * Input:   int itemIDToDelete, specifies the ItemID to delete.
         * Output:  bool, represents whether the deletion was successful or not.
        ------------------------------------------------------------------------------------------*/
        public bool Delete(int itemIDToDelete)
        {
            try
            {
                itemList.RemoveAt(GetItemIndex(itemIDToDelete));
                IsChanged = true;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    DisplayAll
         * Type:    Method
         * Purpose: Display a paginated list of all the items in the ItemDB object. Can be a
         *          simplified list or not.
         * Input:   bool simplified, tells the method whether it should display simplified listing
         *          or not.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        public void DisplayAll(bool simplified = false)
        {
            // Helper constants to determine how many lines are going to be used for displaying each
            // type of item.
            const int linesDisplayedPerBusiness = 10;
            const int linesDisplayedPerPark = 12;
            const int linesDisplayedPerPublicFacility = 6;
            const int linesDisplayedSimplified = 4;

            // Variables to help with controlling pagination flow.
            bool displayAll = false;
            int linesToBeDisplayed = 0;
            int linesDisplayed = 0;
            bool validInput = false;
            ConsoleKeyInfo keyPress;

            foreach (var item in itemList)
            {
                // If the user has chosen to display everything, don't both with the other logic.
                if (!displayAll)
                {
                    // Figure out how many lines are about to be displayed.
                    if (simplified)
                        linesToBeDisplayed = linesDisplayedSimplified;
                    else if (item.ItemType == "business")
                        linesToBeDisplayed = linesDisplayedPerBusiness;
                    else if (item.ItemType == "park")
                        linesToBeDisplayed = linesDisplayedPerPark;
                    else if (item.ItemType == "publicfacility")
                        linesToBeDisplayed = linesDisplayedPerPublicFacility;

                    // If the number of lines about to be displayed will put the displayed number of
                    // lines since last reset at greater than the number of lines available for
                    // display, pause output and ask the user what to do.
                    if (linesDisplayed + linesToBeDisplayed >= Console.WindowHeight - 1)
                    {
                        Console.WriteLine("Enter for next item. Space for next page. " +
                            "Ctrl+Enter for all. Esc to abort.\n");
                        do
                        {
                            // Reset valid input flag and read user input.
                            validInput = false;
                            keyPress = Console.ReadKey(true);

                            switch (keyPress.Key)
                            {
                                case ConsoleKey.Escape:
                                    if (keyPress.Modifiers == 0)
                                        // User pressed Escape key; abort display method.
                                        return;
                                    break;

                                case ConsoleKey.Spacebar:
                                    if (keyPress.Modifiers == 0)
                                    {
                                        // User wishes to display another page; reset the number of
                                        // lines displayed to 0.
                                        linesDisplayed = 0;
                                        validInput = true;
                                    }
                                    break;

                                case ConsoleKey.Enter:
                                    if (keyPress.Modifiers == ConsoleModifiers.Control)
                                    {
                                        // User wishes to display everything.
                                        displayAll = true;
                                        validInput = true;
                                    }
                                    else if (keyPress.Modifiers == 0)
                                    {
                                        // User wishes to display only the next item.
                                        linesDisplayed -= linesToBeDisplayed;
                                        validInput = true;
                                    }
                                    break;

                                default:
                                    break;
                            }
                            // Loop while the user has not provided valid input.
                        } while (!validInput);
                    }
                    // Update the number of lines that have been displayed.
                    linesDisplayed += linesToBeDisplayed;
                }
                // Display the item. Must use the ToString() method, otherwise VS complains that
                // there are no implicit conversions between Item and string types.
                Console.WriteLine("{0}\n", simplified ? item.ToStringSimple() : item.ToString());
            }

            if (itemList.Count == 0)
                Console.WriteLine("No items to display.\n");
        }

        /*------------------------------------------------------------------------------------------
         * Name:    GetItem
         * Type:    Method
         * Purpose: Get a copy of the item with the specified ItemID.
         * Input:   int itemID, the itemID of the item to get.
         * Output:  Item, contains a copy of the object with itemID, or null if not found.
        ------------------------------------------------------------------------------------------*/
        public Item GetItem(int itemID)
        {
            Item tempItem = itemList.Find(i => i.ItemID == itemID);

            if (tempItem is Business)
                return new Business(tempItem as Business);
            else if (tempItem is Park)
                return new Park(tempItem as Park);
            else if (tempItem is PublicFacility)
                return new PublicFacility(tempItem as PublicFacility);
            else
                return null;
        }

        /*------------------------------------------------------------------------------------------
         * Name:    GetItemIndex
         * Type:    Method
         * Purpose: Finds the index of the specified item ID.
         * Input:   int itemID, contains the item ID to search for.
         * Output:  int, contains the index where the item ID can be found.
        ------------------------------------------------------------------------------------------*/
        public int GetItemIndex(int itemID)
        {
            return itemList.FindIndex(i => i.ItemID == itemID);
        }

        /*------------------------------------------------------------------------------------------
         * Name:    Modify
         * Type:    Method
         * Purpose: Modifies an Item in the list.
         * Input:   Item item, contains the item that will be matched with and replace the item with
         *          the same ItemID.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        public void Modify(Item item)
        {
            int index = GetItemIndex(item.ItemID);

            // Verify that the ItemID is in the list and that ItemType is the same.
            if (index >= 0 && itemList[index].ItemType == item.ItemType)
                // Verify that the items are of the same type.
                if ((itemList[index] is Business && item is Business) ||
                    (itemList[index] is Park && item is Park) ||
                    (itemList[index] is PublicFacility && item is PublicFacility))
                {
                    // Replace the item reference in the list.
                    itemList[index] = item;
                    IsChanged = true;
                }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    Reset
         * Type:    Method
         * Purpose: Clears the ItemDB, resets currentItemKey, and resets IsChanged.
         * Input:   Nothing.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        public void Reset()
        {
            itemList.Clear();
            currentItemKey = KeyStart;
            IsChanged = false;
        }

        /*------------------------------------------------------------------------------------------
         * Name:    Search
         * Type:    Method
         * Purpose: Performs a search based on the comparator on the specified item type and field.
         * Input:   string toSearchFor, contains the string that is being searched for.
         * Input:   string itemType, contains the item type to search through.
         * Input:   Item.FieldMenuHelper field, contains the field to search through.
         * Input:   string comparator, contains the comparator that will be used. Valid choices are
         *          !=, =, <=, >=, <, >, and !|. Everything else does a "contains"-style search.
         * Output:  ItemDB object that contains the results of the search.
        ------------------------------------------------------------------------------------------*/
        public ItemDB Search(string toSearchFor, string itemType, Item.FieldMenuHelper field,
            string comparator = "")
        {
            if (itemList.Count == 0)
                return this;

            var ignoreCase = StringComparison.OrdinalIgnoreCase;

            // Create base list and object for ease-of-use inside the switch.
            var typeLimitedList = this.itemList.Where(i => i.ItemType == itemType);
            object baseObject = typeLimitedList.Select(i => i[field]).First();

            switch (comparator)
            {
                case "!=":
                    if (baseObject is DateTime)
                        return new ItemDB() { itemList = typeLimitedList.
                            Where(i => (DateTime)i[field] != SimpleConvert.ToDateTime(toSearchFor)).
                            ToList() };
                    else if (baseObject is float)
                        return new ItemDB() { itemList = typeLimitedList.
                            Where(i => (float)i[field] != SimpleConvert.ToSingle(toSearchFor)).
                            ToList() };
                    else if (baseObject is int)
                        return new ItemDB() { itemList = typeLimitedList.
                            Where(i => (int)i[field] != SimpleConvert.ToInt32(toSearchFor)).
                            ToList() };
                    else
                        return new ItemDB() { itemList = typeLimitedList.
                            Where(i => (string)i[field] != toSearchFor).
                            ToList() };

                case "=":
                    if (baseObject is DateTime)
                        return new ItemDB() { itemList = typeLimitedList.
                            Where(i => (DateTime)i[field] == SimpleConvert.ToDateTime(toSearchFor)).
                            ToList() };
                    else if (baseObject is float)
                        return new ItemDB() { itemList = typeLimitedList.
                            Where(i => (float)i[field] == SimpleConvert.ToSingle(toSearchFor)).
                            ToList() };
                    else if (baseObject is int)
                        return new ItemDB() { itemList = typeLimitedList.
                            Where(i => (int)i[field] == SimpleConvert.ToInt32(toSearchFor)).
                            ToList() };
                    else
                        return new ItemDB() { itemList = typeLimitedList.
                            Where(i => (string)i[field] == toSearchFor).
                            ToList() };

                case "<=":
                    if (baseObject is DateTime)
                        return new ItemDB() { itemList = typeLimitedList.
                            Where(i => (DateTime)i[field] <= SimpleConvert.ToDateTime(toSearchFor)).
                            ToList() };
                    else if (baseObject is float)
                        return new ItemDB() { itemList = typeLimitedList.
                            Where(i => (float)i[field] <= SimpleConvert.ToSingle(toSearchFor)).
                            ToList() };
                    else if (baseObject is int)
                        return new ItemDB() { itemList = typeLimitedList.
                            Where(i => (int)i[field] <= SimpleConvert.ToInt32(toSearchFor)).
                            ToList() };
                    else
                        Console.WriteLine(
                            "That comparator doesn't work for this field. Switching to |.");
                    break;

                case ">=":
                    if (baseObject is DateTime)
                        return new ItemDB() { itemList = typeLimitedList.
                            Where(i => (DateTime)i[field] >= SimpleConvert.ToDateTime(toSearchFor)).
                            ToList() };
                    else if (baseObject is float)
                        return new ItemDB() { itemList = typeLimitedList.
                            Where(i => (float)i[field] >= SimpleConvert.ToSingle(toSearchFor)).
                            ToList() };
                    else if (baseObject is int)
                        return new ItemDB() { itemList = typeLimitedList.
                            Where(i => (int)i[field] >= SimpleConvert.ToInt32(toSearchFor)).
                            ToList() };
                    else
                        Console.WriteLine(
                            "That comparator doesn't work for this field. Switching to |.");
                    break;

                case "<":
                    if (baseObject is DateTime)
                        return new ItemDB() { itemList = typeLimitedList.
                            Where(i => (DateTime)i[field] < SimpleConvert.ToDateTime(toSearchFor)).
                            ToList() };
                    else if (baseObject is float)
                        return new ItemDB() { itemList = typeLimitedList.
                            Where(i => (float)i[field] < SimpleConvert.ToSingle(toSearchFor)).
                            ToList() };
                    else if (baseObject is int)
                        return new ItemDB() { itemList = typeLimitedList.
                            Where(i => (int)i[field] < SimpleConvert.ToInt32(toSearchFor)).
                            ToList() };
                    else
                        Console.WriteLine(
                            "That comparator doesn't work for this field. Switching to |.");
                    break;

                case ">":
                    if (baseObject is DateTime)
                        return new ItemDB() { itemList = typeLimitedList.
                            Where(i => (DateTime)i[field] > SimpleConvert.ToDateTime(toSearchFor)).
                            ToList() };
                    else if (baseObject is float)
                        return new ItemDB() { itemList = typeLimitedList.
                            Where(i => (float)i[field] > SimpleConvert.ToSingle(toSearchFor)).
                            ToList() };
                    else if (baseObject is int)
                        return new ItemDB() { itemList = typeLimitedList.
                            Where(i => (int)i[field] > SimpleConvert.ToInt32(toSearchFor)).
                            ToList() };
                    else
                        Console.WriteLine(
                            "That comparator doesn't work for this field. Switching to |.");
                    break;

                case "!|":
                    return new ItemDB() { itemList = typeLimitedList.
                        Where(i => i[field].ToString().IndexOf(toSearchFor, ignoreCase) < 0).
                        ToList() };

                default:
                    break;
            }

            // Default/catch-all search.
            return new ItemDB() { itemList = typeLimitedList.
                Where(i => i[field].ToString().IndexOf(toSearchFor, ignoreCase) >= 0).
                ToList() };
        }

        /*------------------------------------------------------------------------------------------
         * Name:    Statistics
         * Type:    Method
         * Purpose: Displays the number of unique Type fields, and then displays the field values
         *          and their count.
         * Input:   Nothing.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        public void Statistics()
        {
            // Create a Dictionary to keep track of the unique Item.Type values.
            Dictionary<string, int> types = new Dictionary<string, int>();

            // Get a sorted lowercase list of unique Item.Type values and Add the aforementioned
            // list to the dictionary.
            var uniqueTypes = itemList.Select(i => i.Type.ToLower()).Distinct().OrderBy(s => s);
            foreach (var type in uniqueTypes)
                types.Add(type, 0);

            // Run through the list and increment the count of any type when it is encountered, then
            // display all the results.
            foreach (var item in itemList)
                types[item.Type.ToLower()]++;
            Console.WriteLine("{0} unique type{1} of item{1} found.\n", types.Count,
                types.Count != 1 ? "s" : "");
            foreach (var type in types)
                Console.WriteLine("{0}: {1}", type.Key, type.Value);
            if (types.Count > 0)
                Console.WriteLine();
        }

        // Implementation for the GetEnumerator method. Source:
        // https://msdn.microsoft.com/en-us/library/system.collections.ienumerable(v=vs.110).aspx
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public ItemDBEnum GetEnumerator()
        {
            return new ItemDBEnum(itemList);
        }
    }

    public class ItemDBEnum : IEnumerator
    {
        // Enumerator for the ItemDB class. Much help came from MSDN.
        // https://msdn.microsoft.com/en-us/library/system.collections.ienumerable(v=vs.110).aspx

        private List<Item> itemList;

        int position = -1;

        public ItemDBEnum(List<Item> list)
        {
            itemList = list;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

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

        public bool MoveNext()
        {
            position++;
            return (position < itemList.Count);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
