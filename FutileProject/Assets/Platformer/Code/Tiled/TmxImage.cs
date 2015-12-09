using System.Xml.Serialization;


namespace Platformer.Tiled
{
	public class TmxImage
	{
		public TmxImage()
		{}


		public override string ToString()
		{
			return source;
		}


		[XmlAttribute( AttributeName = "source" )]
		public string source;

		[XmlAttribute( AttributeName = "width" )]
		public int width;

		[XmlAttribute( AttributeName = "height" )]
		public int height;

		[XmlAttribute( AttributeName = "format" )]
		public string format;

		[XmlAttribute( AttributeName = "trans" )]
		public string trans;

		[XmlElement( ElementName = "data" )]
		public TmxData data;

	}
}