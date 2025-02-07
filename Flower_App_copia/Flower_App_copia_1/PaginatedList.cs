using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Flower_App_copia_1
{
    public class PaginatedList<T> : List<T>
    {
        public int PageNumber { get; private set; } // Current page number
        public int TotalPages { get; private set; } // Total number of pages

        public PaginatedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber; // Set current page number
            TotalPages = (int)Math.Ceiling(count / (double)pageSize); // Calculate total pages

            AddRange(items); // Add items to the list
        }

        public bool HasPreviousPage => PageNumber > 1; // Check if there is a previous page
        public bool HasNextPage => PageNumber < TotalPages; // Check if there is a next page
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync(); // Get total count of items
            var items = await source.Skip((pageNumber - 1) * pageSize) // Skip previous pages
                .Take(pageSize) // Take items for the current page
                .ToListAsync(); // Execute the query

            return new PaginatedList<T>(items, count, pageNumber, pageSize); // Return new paginated list
        }
    }
}
