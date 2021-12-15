using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lists;

namespace ListsTests
{
    [TestClass]
    public class ListTests
    {
        [DataTestMethod]
        [DataRow(ListType.Singly)]
        [DataRow(ListType.Doubly)]
        [DataRow(ListType.Gary)]
        public void AddFind(ListType listType)
        {
            var list = CreateListType(listType);

            var node = list.Find("Fred");
            Assert.IsTrue(node == default(Node));

            list.Add("Fred");
            node = list.Find("Fred");

            // An exmaple of writing detailed messages out in tests...
            Assert.IsTrue(node.Value == "Fred",$"Failed to Add Fred for {list.GetType().Name}");

            node = list.Find("Wilma");
            Assert.IsTrue(node == default(Node));

            list.Add("Wilma");

            node = list.Find("Fred");
            Assert.IsTrue(node.Value == "Fred");

            node = list.Find("Wilma");
            Assert.IsTrue(node.Value == "Wilma");

            string[] fredAndWilma = new string[] { "Fred", "Wilma" };
            CollectionAssert.AreEqual(list.Values(), fredAndWilma);
        }

        [DataTestMethod]
        [DataRow(ListType.Singly)]
        [DataRow(ListType.Doubly)]
        [DataRow(ListType.Gary)]
        public void Delete(ListType listType)
        {
            var list = CreateListType(listType);

            list.Add("Fred");
            list.Add("Wilma");
            list.Add("Betty");
            list.Add("Barney");

            string[] people = new string[] { "Fred","Wilma","Betty","Barney" };
            CollectionAssert.AreEqual(list.Values(), people);

            var node = list.Find("Wilma");
            Assert.IsTrue(list.Delete(node), "Failed to Delete Wilma");

            people = new string[] { "Fred", "Betty", "Barney" };
            CollectionAssert.AreEqual(list.Values(), people);

            node = list.Find("Barney");
            Assert.IsTrue(list.Delete(node), "Failed to Delete Barney");

            people = new string[] { "Fred", "Betty" };
            CollectionAssert.AreEqual(list.Values(), people);

            node = list.Find("Fred");
            Assert.IsTrue(list.Delete(node),"Failed to Delete Fred");

            people = new string[] { "Betty" };
            CollectionAssert.AreEqual(list.Values(), people);

            node = list.Find("Betty");
            Assert.IsTrue(list.Delete(node), "Failed to Delete Betty");

            people = new string[] { };
            CollectionAssert.AreEqual(list.Values(), people);
        }

        #region Helpers
        private ILinkedList CreateListType(ListType listType)
        {
            ILinkedList list = null;

            //Could use an Activator here rather than switch but keep simple for tests.
            switch (listType)
            {
                case ListType.Singly:
                    list = new SinglyLinkedList();
                    break;
                case ListType.Doubly:
                    list = new DoublyLinkedList();
                    break;
                case ListType.Gary:
                    list = new GaryList();
                    break;
            }

            return list;
        }

        public enum ListType
        {
            Singly,
            Doubly,
            Gary
        }

        #endregion
    }
}
