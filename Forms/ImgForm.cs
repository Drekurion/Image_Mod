using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APO_Projekt
{
    /// <summary>
    /// Form for displaying an image in the application. Docked to Picture class.
    /// </summary>
	public partial class ImgForm : Form
	{
        private Picture handle;
		public ImgForm(Picture handle)
		{
			InitializeComponent();
            this.handle = handle;
			this.display.Image = handle.Img;
			this.Text = handle.Filename;
		}

        #region "Line Drawing"

        // The "size" of an object for mouse over purposes.
        private const int object_radius = 3;

        // We're over an object if the distance squared
        // between the mouse and the object is less than this.
        private const int over_dist_squared = object_radius * object_radius;

        // The points that make up the line segments.
        private Point Pt1, Pt2;

        // Points for the new line.
        private bool IsDrawing = false;
        private Point NewPt1, NewPt2;

        // The mouse is up. See whether we're over an end point or segment.
        private void pictureBox_MouseMove_NotDown(object sender, MouseEventArgs e)
		{
			Cursor new_cursor = Cursors.Cross;

			// See what we're over.
			Point hit_point;

			if (MouseIsOverEndpoint(e.Location, out hit_point))
				new_cursor = Cursors.Arrow;
			else if (MouseIsOverSegment(e.Location))
				new_cursor = Cursors.Hand;

			// Set the new cursor.
			if (display.Cursor != new_cursor)
				display.Cursor = new_cursor;
		}

        // See what we're over and start doing whatever is appropriate.
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // See what we're over.
            Point hit_point;

            if (MouseIsOverEndpoint(e.Location, out hit_point))
            {
                // Start moving this end point.
                display.MouseMove -= pictureBox_MouseMove_NotDown;
                display.MouseMove += pictureBox_MouseMove_MovingEndPoint;
                display.MouseUp += pictureBox_MouseUp_MovingEndPoint;

                // See if we're moving the start end point.
                MovingStartEndPoint = (Pt1.Equals(hit_point));

                // Remember the offset from the mouse to the point.
                OffsetX = hit_point.X - e.X;
                OffsetY = hit_point.Y - e.Y;
            }
            else if (MouseIsOverSegment(e.Location))
            {
                // Start moving this segment.
                display.MouseMove -= pictureBox_MouseMove_NotDown;
                display.MouseMove += pictureBox_MouseMove_MovingSegment;
                display.MouseUp += pictureBox_MouseUp_MovingSegment;

                // Remember the offset from the mouse to the segment's first point.
                OffsetX = Pt1.X - e.X;
                OffsetY = Pt1.Y - e.Y;
            }
            else
            {
                // Start drawing a new segment.
                display.MouseMove -= pictureBox_MouseMove_NotDown;
                display.MouseMove += pictureBox_MouseMove_Drawing;
                display.MouseUp += pictureBox_MouseUp_Drawing;

                IsDrawing = true;
                NewPt1 = new Point(e.X, e.Y);
                NewPt2 = new Point(e.X, e.Y);
            }
        }

        #region "Drawing"

        // We're drawing a new segment.
        private void pictureBox_MouseMove_Drawing(object sender, MouseEventArgs e)
        {
            // Save the new point.
            NewPt2 = new Point(e.X, e.Y);

            // Redraw.
            display.Invalidate();
        }

        // Stop drawing.
        private void pictureBox_MouseUp_Drawing(object sender, MouseEventArgs e)
        {
            IsDrawing = false;

            // Reset the event handlers.
            display.MouseMove -= pictureBox_MouseMove_Drawing;
            display.MouseMove += pictureBox_MouseMove_NotDown;
            display.MouseUp -= pictureBox_MouseUp_Drawing;

            // Create the new segment.
            Pt1 = NewPt1;
            Pt2 = NewPt2;

            // Redraw.
            display.Invalidate();
        }

        #endregion // Drawing

        #region "Moving End Point"

        // The end point we're moving.
        private bool MovingStartEndPoint = false;

        // The offset from the mouse to the object being moved.
        private int OffsetX, OffsetY;

        // We're moving an end point.
        private void pictureBox_MouseMove_MovingEndPoint(object sender, MouseEventArgs e)
        {
            // Move the point to its new location.
            if (MovingStartEndPoint)
                Pt1 = new Point(e.X + OffsetX, e.Y + OffsetY);
            else
                Pt2 = new Point(e.X + OffsetX, e.Y + OffsetY);

            // Redraw.
            display.Invalidate();
        }

        // Stop moving the end point.
        private void pictureBox_MouseUp_MovingEndPoint(object sender, MouseEventArgs e)
        {
            // Reset the event handlers.
            display.MouseMove += pictureBox_MouseMove_NotDown;
            display.MouseMove -= pictureBox_MouseMove_MovingEndPoint;
            display.MouseUp -= pictureBox_MouseUp_MovingEndPoint;

            // Redraw.
            display.Invalidate();
        }

        #endregion // Moving End Point

        #region "Moving Segment"

        // We're moving a segment.
        private void pictureBox_MouseMove_MovingSegment(object sender, MouseEventArgs e)
        {
            // See how far the first point will move.
            int new_x1 = e.X + OffsetX;
            int new_y1 = e.Y + OffsetY;

            int dx = new_x1 - Pt1.X;
            int dy = new_y1 - Pt1.Y;

            if (dx == 0 && dy == 0) return;

            // Move the segment to its new location.
            Pt1 = new Point(new_x1, new_y1);
            Pt2 = new Point(Pt2.X + dx, Pt2.Y + dy);

            // Redraw.
            display.Invalidate();
        }

        // Stop moving the segment.
        private void pictureBox_MouseUp_MovingSegment(object sender, MouseEventArgs e)
        {
            // Reset the event handlers.
            display.MouseMove += pictureBox_MouseMove_NotDown;
            display.MouseMove -= pictureBox_MouseMove_MovingSegment;
            display.MouseUp -= pictureBox_MouseUp_MovingSegment;

            // Redraw.
            display.Invalidate();
        }

        #endregion // Moving Segment

        #region "Mouse is over..."

        // See if the mouse is over an end point.
        private bool MouseIsOverEndpoint(Point mouse_pt, out Point hit_pt)
        {
            // Check the starting point.
            if (FindDistanceToPointSquared(mouse_pt, Pt1) < over_dist_squared)
            {
                // We're over this point.
                hit_pt = Pt1;
                return true;
            }
            // Check the end point.
            if (FindDistanceToPointSquared(mouse_pt, Pt2) < over_dist_squared)
            {
                // We're over this point.
                hit_pt = Pt2;
                return true;
            }
            hit_pt = new Point(-1, -1);
            return false;
        }

        // See if the mouse is over a line segment.
        private bool MouseIsOverSegment(Point mouse_pt)
        {
            // See if we're over the segment.
            PointF closest;
            if (FindDistanceToSegmentSquared(mouse_pt, Pt1, Pt2, out closest) < over_dist_squared)
            {
                // We're over this segment.
                return true;
            }
            return false;
        }
        #endregion // Mouse is over...

        #region "Find distance to..."

        // Calculate the distance squared between two points.
        private int FindDistanceToPointSquared(Point pt1, Point pt2)
        {
            int dx = pt1.X - pt2.X;
            int dy = pt1.Y - pt2.Y;
            return dx * dx + dy * dy;
        }

        // Calculate the distance squared between
        // point pt and the segment p1 --> p2.
        private double FindDistanceToSegmentSquared(Point pt, Point p1, Point p2, out PointF closest)
        {
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            if ((dx == 0) && (dy == 0))
            {
                // It's a point not a line segment.
                closest = p1;
                dx = pt.X - p1.X;
                dy = pt.Y - p1.Y;
                return dx * dx + dy * dy;
            }

            // Calculate the t that minimizes the distance.
            float t = ((pt.X - p1.X) * dx + (pt.Y - p1.Y) * dy) / (dx * dx + dy * dy);

            // See if this represents one of the segment's
            // end points or a point in the middle.
            if (t < 0)
            {
                closest = new PointF(p1.X, p1.Y);
                dx = pt.X - p1.X;
                dy = pt.Y - p1.Y;
            }
            else if (t > 1)
            {
                closest = new PointF(p2.X, p2.Y);
                dx = pt.X - p2.X;
                dy = pt.Y - p2.Y;
            }
            else
            {
                closest = new PointF(p1.X + t * dx, p1.Y + t * dy);
                dx = pt.X - closest.X;
                dy = pt.Y - closest.Y;
            }

            return dx * dx + dy * dy;
        }

        #endregion //Find distance to...

        // Draw the lines.
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            // Draw the segment.
            e.Graphics.DrawLine(Pens.Blue, Pt1, Pt2);

            // Draw the end points.
            Rectangle rect1 = new Rectangle(Pt1.X - object_radius, Pt1.Y - object_radius, 2 * object_radius + 1, 2 * object_radius + 1);
            e.Graphics.FillEllipse(Brushes.White, rect1);
            e.Graphics.DrawEllipse(Pens.Black, rect1);
            Rectangle rect2 = new Rectangle(Pt2.X - object_radius, Pt2.Y - object_radius, 2 * object_radius + 1, 2 * object_radius + 1);
            e.Graphics.FillEllipse(Brushes.White, rect2);
            e.Graphics.DrawEllipse(Pens.Black, rect2);

            // If there's a new segment under constructions, draw it.
            if (IsDrawing)
            {
                e.Graphics.DrawLine(Pens.Red, NewPt1, NewPt2);
            }
        }

        #endregion // Line Drawing

        public void refresh()
		{
			this.display.Image = handle.Img;
		}

        public void changeName()
		{
            this.Text = handle.Filename;
		}

		private void ImgForm_Activated(object sender, EventArgs e)
		{
			PictureList.Focused = handle;
		}

		private void ImgForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			handle.Close();
		}
	}
}
