using System.Xml.Serialization;


namespace Platformer.Tiled
{
	public class TmxTileLayer : TmxLayer
	{
		public TmxTileLayer()
		{}


		[XmlAttribute( AttributeName = "x" )]
		public int x;

		[XmlAttribute( AttributeName = "y" )]
		public int y;

		[XmlAttribute( AttributeName = "width" )]
		public int width;

		[XmlAttribute( AttributeName = "height" )]
		public int height;

		[XmlElement( ElementName = "data" )]
		public TmxData data;
	}
}