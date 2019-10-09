using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyConsole
{
	public class Stack
	{
		#region Class Node (Поставьте фокус сюда и нажмите Ctrl+MM несколько раз)
		class Node
		{
			public Node Next;
			public object Value;
			public Node(object value) : this(value, null) { } // Вызов другого конструктора
			public Node(object value, Node next)
			{
				Next = next;
				Value = value;
			}
		}
		#endregion

		Node top = null;	// Вершина стека

		public bool IsEmpty() { return top == null; }
		public void Push(object o) { top = new Node(o, top); }
		public object Pop()
		{
			if (top == null)
				throw new Exception("Can't Pop from an empty Stack");
			else
			{
				object pop = top.Value;
				top = top.Next;
				return pop;
			}
		}
	}

}
