using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APO_Projekt
{
	/// <summary>
	/// Class holding history of the images for undo/redo operations.
	/// </summary>
	class History
	{
		private Stack<Bitmap> undoStack = new Stack<Bitmap>();
		private Stack<Bitmap> redoStack = new Stack<Bitmap>();

		/// <summary>
		/// Adds image to history.
		/// </summary>
		/// <param name="oldImage">Image to be added to history.</param>
		public void Add(Bitmap oldImage)
		{
			undoStack.Push(oldImage);
		}
		/// <summary>
		/// Takes previous image from history.
		/// </summary>
		/// <param name="currentImage">Current image added to history in case of redo operation.</param>
		/// <returns>Previous image.</returns>
		public Bitmap Undo(Bitmap currentImage)
		{
			Bitmap oldImage = undoStack.Pop();
			redoStack.Push(currentImage);
			return oldImage;
		}
		/// <summary>
		/// Takes next image from history.
		/// </summary>
		/// <param name="currentImage">Current image added to history in case of undo operation.</param>
		/// <returns>Next image.</returns>
		public Bitmap Redo(Bitmap currentImage)
		{
			Bitmap oldImage = redoStack.Pop();
			undoStack.Push(currentImage);
			return oldImage;
		}
		/// <summary>
		/// Returns true if no previous image was added to history.
		/// </summary>
		public bool UndoEmpty
		{
			get { return undoStack.Count == 0; }
		}
		/// <summary>
		/// Returns true if no next image was added to history.
		/// </summary>
		public bool RedoEmpty
		{
			get { return redoStack.Count == 0; }
		}
	}
}
