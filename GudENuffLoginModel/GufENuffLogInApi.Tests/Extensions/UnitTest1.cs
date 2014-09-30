using System;
using GufENuffLogInApi.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GufENuffLogInApi.Tests.Extensions
{
	[TestClass]
	public class StringExtensionsTest
	{
		[TestMethod]
		public void HasDigitsPositiveTest()
		{
			string value = "TestString123TestString";

			var output = value.HasDigits();

			Assert.AreEqual( true, output );
		}
		[TestMethod]
		public void HasDigitsNegativeTest()
		{
			string value = "TestStringTestString";

			var output = value.HasDigits();

			Assert.AreEqual( false, output );
		}
		[TestMethod]
		public void HasLettersPositiveTest()
		{
			string value = "123141HasLetters213123";

			var output = value.HasLetters();

			Assert.AreEqual( true, output );
		}
		[TestMethod]
		public void HasLettersNegativeTest()
		{
			string value = "123141213123";

			var output = value.HasLetters();

			Assert.AreEqual( false, output );
		}
		[TestMethod]
		public void HasCapitalPositiveTest()
		{
			string value = "hasCApitalLetters";

			var output = value.HasCapital();

			Assert.AreEqual( true, output );
		}
		[TestMethod]
		public void HasCapitalNegativeTest()
		{
			string value = "nocapschamp";

			var output = value.HasCapital();

			Assert.AreEqual( false, output );
		}
		[TestMethod]
		public void HasSymbolsPositiveTest()
		{
			string value = "hasSymbols&&&12313";

			var output = value.HasSymbols();

			Assert.AreEqual( true, output );
		}
		[TestMethod]
		public void HasSymbolsNegativeTest()
		{
			string value = "nohasSymbols12313";

			var output = value.HasSymbols();

			Assert.AreEqual( false, output );
		}
		[TestMethod]
		public void HasIllegalPositiveTest()
		{
			string value = "fdakofmfa*@#&*!#(!@(fokaofk23131";

			var output = value.HasIllegalCharacters();

			Assert.AreEqual( true, output );
		}
		[TestMethod]
		public void HasIllegalNegativeTest()
		{
			string value = "sddaoindij&*dioajdio123129321841";

			var output = value.HasIllegalCharacters();

			Assert.AreEqual( false, output );
		}
	}
}
