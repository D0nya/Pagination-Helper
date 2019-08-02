using System;
using System.Collections.Generic;

namespace PageHelper
{
  public static class Program
  {
    public static void  Main()
    {
      PagnationHelper<int> p = new PagnationHelper<int>(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 345, 6, 5, 4, 6, 6 }, 4);
      Console.WriteLine(p.ItemCount);
      Console.WriteLine(p.PageCount);
      Console.WriteLine();

      Console.WriteLine(p.PageItemCount(0));
      Console.WriteLine(p.PageItemCount(1));
      Console.WriteLine(p.PageItemCount(2));
      Console.WriteLine(p.PageItemCount(3));
      Console.WriteLine(p.PageItemCount(4));
      Console.WriteLine(p.PageItemCount(5));
      Console.WriteLine(p.PageItemCount(-1));
      Console.WriteLine();

      Console.WriteLine(p.PageIndex(6));
      Console.WriteLine(p.PageIndex(0));
      Console.WriteLine(p.PageIndex(8));
      Console.WriteLine(p.PageIndex(12));
      Console.WriteLine(p.PageIndex(200));
      Console.WriteLine(p.PageIndex(-4));
    }
  }


  public class PagnationHelper<T>
  {
    private readonly int itemsPerPage;
    /// <summary>
    /// Constructor, takes in a list of items and the number of items that fit within a single page
    /// </summary>
    /// <param name="collection">A list of items</param>
    /// <param name="itemsPerPage">The number of items that fit within a single page</param>
    public PagnationHelper(IList<T> collection, int itemsPerPage)
    {
      this.itemsPerPage = itemsPerPage;
      ItemCount = collection.Count;
      PageCount = (ItemCount + itemsPerPage - 1) / itemsPerPage;
    }

    /// <summary>
    /// The number of items within the collection
    /// </summary>
    public int ItemCount { get; }

    /// <summary>
    /// The number of pages
    /// </summary>
    public int PageCount { get; }
    /// <summary>
    /// Returns the number of items in the page at the given page index 
    /// </summary>
    /// <param name="pageIndex">The zero-based page index to get the number of items for</param>
    /// <returns>The number of items on the specified page or -1 for pageIndex values that are out of range</returns>
    public int PageItemCount(int pageIndex)
    {
      if (pageIndex < 0 || pageIndex >= PageCount)
        return -1;

      if (pageIndex == PageCount - 1)
        return ItemCount - itemsPerPage * pageIndex;

      return itemsPerPage;
    }

    /// <summary>
    /// Returns the page index of the page containing the item at the given item index.
    /// </summary>
    /// <param name="itemIndex">The zero-based index of the item to get the pageIndex for</param>
    /// <returns>The zero-based page index of the page containing the item at the given item index or -1 if the item index is out of range</returns>
    public int PageIndex(int itemIndex)
    {
      if (itemIndex < 0 || itemIndex >= ItemCount)
        return -1; ;

      return itemIndex / itemsPerPage;
    }
  }
}

