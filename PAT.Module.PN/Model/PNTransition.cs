using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PAT.Common.GUI.Drawing;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using System.Web;
using System.Globalization;
using PAT.Common.ModelCommon.PNCommon;
using PAT.Common.ModelCommon;

namespace PAT.Module.PN.Model
{
    public class PNTransition : StateItem
    {
        private string _id;
        private List<PNPlace> _inputPlaces = new List<PNPlace>();
        public List<PNPlace> InputPlaces
        {
            get { return _inputPlaces; }
        }

        private List<PNPlace> _outputPlaces = new List<PNPlace>();
        public List<PNPlace> OutputPlaces
        {
            get { return _outputPlaces; }
        }

        private string _guard;
        public string Guard
        {
            get { return _guard; }
            set { _guard = value; }
        }

        private string _program;
        public string Program
        {
            get { return _program; }
            set { _program = value; }
        }

        public PNTransition(string name, string id, int color)
            : base(false, name)
        {
            // TODO: Complete member initialization
            _program = string.Empty;
            _guard = string.Empty;
            freeColor = color;
            _id = id;
        }

        public override void DrawToGraphics(Graphics graphics)
        {
            Brush pthGrBrush = Brushes.Black;
            Pen pen = new Pen(Color.Black);
            RectangleF EllipseFill = new RectangleF(AbsoluteX + 5, AbsoluteY - 2, 10, 24);

            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(EllipseFill);

            Brush TextColor = Brushes.Black;
            switch (this.CurrentState)
            {
                case ItemState.Free:
                    pthGrBrush = new SolidBrush(Color.Black);
                    if (freeColor != 0)
                    {
                        pthGrBrush = new SolidBrush((freeColor > 0) ? getFreeColors[freeColor - 1, 1] : getFreeColors[(-1) * freeColor - 1, 3]);
                        if (freeColor == 2) pthGrBrush = new SolidBrush(Color.DarkOrchid);
                    }
                    break;

                case ItemState.Hover:
                    pthGrBrush = new SolidBrush(ColorDefinition.GetColorWhenHover());
                    TextColor = Brushes.White;
                    break;

                case ItemState.Selected:
                    pthGrBrush = new SolidBrush(ColorDefinition.GetColorWhenSelected());
                    break;

                default:
                    break;
            } // switch

            graphics.FillRectangle(pthGrBrush, EllipseFill);
            graphics.DrawRectangle(pen, AbsoluteX + 5, AbsoluteY - 2, 10, 24);

            this.labelItems.labels.Clear();
            this.labelItems.colors.Clear();

            Color color = Color.Black;
            switch (this.CurrentState)
            {
                case ItemState.Hover:
                    color = ColorDefinition.GetColorWhenHover();
                    break;

                case ItemState.Selected:
                    color = ColorDefinition.GetColorWhenSelected();
                    break;

                default:
                    break;
            } // switch

            if (this.CurrentState == ItemState.Free)
                color = ColorDefinition.GetColorOfName();

            this.labelItems.labels.Add(Name);
            this.labelItems.colors.Add(color);

            this.labelItems.DrawToGraphics(graphics);

            DrawDecorators(graphics);
        }

        public override void HandleMouseUp(PointF pos)
        {
            base.HandleMouseUp(pos);
            labelItems.MoveFast(AbsoluteX - 10, AbsoluteY + 25);
        }


        public override XmlElement WriteToXml(XmlDocument document)
        {
            XmlElement elem = CreateXmlElement(document);
            FillXmlElement(elem, document);
            elem.AppendChild(this.labelItems.WriteToXml(document));

            elem.SetAttribute(XmlTag.TAG_REFERENCE_ID, _id);

            XmlElement eGuard = document.CreateElement("Guard");
            eGuard.InnerText = HttpUtility.HtmlEncode(_guard);
            elem.AppendChild(eGuard);

            XmlElement eProgram = document.CreateElement("Program");
            eProgram.InnerText = _program;
            elem.AppendChild(eProgram);

            return elem;
        }

        protected override XmlElement CreateXmlElement(XmlDocument doc)
        {
            return doc.CreateElement("Transition");
        }

        protected override void FillXmlElement(XmlElement element, XmlDocument document)
        {
            XmlElement position = document.CreateElement("Position");
            FillXmlPositionElement(position, document);
            element.AppendChild(position);
            element.SetAttribute("Name", Name);
        }

        public override void LoadFromXml(XmlElement XMLelement)
        {
            try
            {
                XmlNodeList position = XMLelement.GetElementsByTagName("Position");
                foreach (XmlElement element in position)
                {
                    X = 100 * float.Parse(element.GetAttribute("X", ""), CultureInfo.InvariantCulture);
                    Y = 100 * float.Parse(element.GetAttribute("Y", ""), CultureInfo.InvariantCulture);
                    Width = 100 * float.Parse(element.GetAttribute("Width", ""), CultureInfo.InvariantCulture);
                    break;
                }
            }
            catch { }

            this.labelItems.LoadFromXml(XMLelement.ChildNodes[1] as XmlElement);
            Guard = HttpUtility.HtmlDecode(XMLelement.GetElementsByTagName("Guard")[0].InnerText);
            Program = XMLelement.GetElementsByTagName("Program")[0].InnerText;
            Name = XMLelement.GetAttribute("Name");
        }
    }
}
