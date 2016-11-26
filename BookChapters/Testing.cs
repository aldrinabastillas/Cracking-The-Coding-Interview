using System;
namespace CrackingTheCodingInterview
{
	public class Testing
	{
		public Testing()
		{
			/* Question 12.3 */

			//Test that the function boolean canMoveTo(int x, int y) 
			//returns the correct answer for a piece in chess

			//Normal Cases
			//	Have to enumerate through all the different types pieces
			//	Test cases where another piece is already in that spot
			//Extreme Cases
			//  integers larger than board size in both directions
			//Null/Illegal inputs
			//	nothing passed in for one or either parameter
			//  a decimal or string passed in
			//  negative numbers
			//Strange Input
			// move 2 for a pawn, can only work on first turn



			/* Question 12.4 */

			//How would you load-test a page without using any test tools?

			//first define metrics of the load-test
			//	response time, throughput, resource utilization, max load of system

			//1: Manual tests
			//	manually open many tabs/windows of that same page, or different pages
			//	copy and paste large pieces of text
			//	manually click refresh many times

			//2: Automated tests
			//	create performance counters in web.config
			//  make many threads running the page
			//  create virtual users

		}
	}
}
