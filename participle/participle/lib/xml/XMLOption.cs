using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace participle.lib.xml
{
 public class xmlread
    {
        public string name;
        public string error;
        public string hand_type;
        protected XmlReader xml;
        protected SortedDictionary<string, SortedDictionary<string, string>> mdata;
        protected SortedDictionary<string, string> mm;
        public xmlread()
        {

            this.name = "";
            this.error = "";
            this.hand_type = "";
            this.mdata = new SortedDictionary<string, SortedDictionary<string, string>>();
            this.mm = new SortedDictionary<string, string>();


        }
        public void init(string url)
        {
            this.xml = XmlReader.Create(url);

            prase();

        }
        public void init(Stream m)
        {
            this.xml = XmlReader.Create(m);
            prase();
        }
        private void prase()
        {

            int i = 0;
            this.xml.MoveToContent();
            string ff = "";
            while (this.xml.Read())
            {

                switch (this.xml.NodeType)
                {
                    case XmlNodeType.Element:
                        Console.Write("<{0}>", ff = this.xml.Name);
                        // ff = this.xml.Name;
                        if (ff == "un" + i)
                        {
                            Console.Write("fffffffffffffffff");
                            //XmlReader ffg = this.xml.ReadSubtree();
                            //Console.Write("fffffffffffffffff{0}",ffg.ReadOuterXml());
                            prase1(this.xml, ff);
                            this.xml.Skip();
                            i++;
                        }
                        break;

                    case XmlNodeType.Text:
                        {
                            Console.Write("\n{0},{1}\n", ff, this.xml.Value);
                            if (ff == "name")
                            {
                                //Console.Write("sdsfad");
                                this.name = this.xml.Value;

                            }
                            else if (ff == "error")
                            {

                                this.error = this.xml.Value;

                            }
                            else if (ff == "hand_type")
                            {

                                this.hand_type = this.xml.Value;

                            }
                            break;
                        }
                    case XmlNodeType.CDATA:
                        // Console.Write("<![CDATA[{0}]]>", this.xml.Value);
                        break;
                    case XmlNodeType.ProcessingInstruction:
                        // Console.Write("<?{0} {1}?>", this.xml.Name, this.xml.Value);
                        break;
                    case XmlNodeType.Comment:
                        // Console.Write("<!--{0}-->", this.xml.Value);
                        break;
                    case XmlNodeType.XmlDeclaration:
                        //Console.Write("<?xml version='1.0'?>");
                        break;
                    case XmlNodeType.Document:
                        break;
                    case XmlNodeType.DocumentType:
                        /// Console.Write("<!DOCTYPE {0} [{1}]", this.xml.Name, this.xml.Value);
                        break;
                    case XmlNodeType.EntityReference:
                        //  Console.Write(this.xml.Name);
                        break;
                    case XmlNodeType.EndElement:
                        // Console.Write("</{0}>", this.xml.Name);
                        break;
                }
                // Console.Write("\nname:{0},value:{1}\n",this.xml.Name,this.xml.Value);
            }
        }
        protected void prase1(XmlReader mm, string dd)
        {
            SortedDictionary<string, string> mn = new SortedDictionary<string, string>();
            //int i = 0;
            mm.MoveToContent();
            string ff = "";
            string dd1 = "";
            while (mm.Read())
            {

                switch (mm.NodeType)
                {
                    case XmlNodeType.Element:
                        // Console.Write("<{0}>", ff = this.xml.Name);
                        ff = this.xml.Name;

                        break;
                    case XmlNodeType.Text:
                        {
                            //  Console.Write("{0},{1}", ff, mm.Value);

                            //mm.Read();
                            mn.Add(ff, mm.Value);
                        }
                        break;
                    case XmlNodeType.EndElement:
                        // Console.Write("</{0}>", this.xml.Name);
                        dd1 = this.xml.Name;
                        // if(dd=="un")
                        break;
                }
                if (dd1 == "un") { break; }

            }
            this.mdata.Add(dd, mn);

        }
        public string getdata(string k, string j)
        {

            this.mm = this.mdata[k];




            return this.mm[j];

        }
        public void close()
        {

            this.xml.Close();
        }
        public SortedDictionary<string, SortedDictionary<string, string>> getmdata()
        {

            return this.mdata;



        }
        // public SortedDictionary<string></


    }
 public class xmlread_j
    {


        public string name;
        public string error;
        public string hand_type;
        protected XmlReader xml;
        // protected SortedDictionary<string, SortedDictionary<string, string>> mdata;
        protected SortedDictionary<string, string> mm;
        public SortedDictionary<string, string> getsort()
        {


            return this.mm;

        }
        public xmlread_j()
        {

            this.name = "";
            this.error = "";
            this.hand_type = "";
            // this.mdata = new SortedDictionary<string, SortedDictionary<string, string>>();
            this.mm = new SortedDictionary<string, string>();
            // prase();

        }
        public void init(string url)
        {
            this.xml = XmlReader.Create(url);

            prase();

        }
        public void init(TextReader m)
        {
            this.xml = XmlReader.Create(m);
            prase();
        }

        private void prase()
        {

            int i = 0;
            this.xml.MoveToContent();
            string ff = "";
            while (this.xml.Read())
            {

                switch (this.xml.NodeType)
                {
                    case XmlNodeType.Element:
                        Console.Write("<{0}>", ff = this.xml.Name);
                        // Console.Write("<{0}>", ff = this.xml.Name);
                        // ff = this.xml.Name;
                        if (ff == "body")
                        {
                            Console.Write("fffffffffffffffff");
                            //XmlReader ffg = this.xml.ReadSubtree();
                            //Console.Write("fffffffffffffffff{0}",ffg.ReadOuterXml());
                            prase1(this.xml, ff);
                            this.xml.Skip();
                            i++;
                        }
                        break;
                    // break;
                    case XmlNodeType.Text:
                        {
                            Console.Write("{0}{1}", this.xml.Name, this.xml.Value);
                            if (ff == "name")
                            {

                                this.name = this.xml.Value;

                            }
                            else if (ff == "error")
                            {

                                this.error = this.xml.Value;

                            }
                            else if (ff == "hand_type")
                            {

                                this.hand_type = this.xml.Value;

                            }


                            break;
                        }
                    case XmlNodeType.CDATA:
                        // Console.Write("<![CDATA[{0}]]>", this.xml.Value);
                        break;
                    case XmlNodeType.ProcessingInstruction:
                        // Console.Write("<?{0} {1}?>", this.xml.Name, this.xml.Value);
                        break;
                    case XmlNodeType.Comment:
                        // Console.Write("<!--{0}-->", this.xml.Value);
                        break;
                    case XmlNodeType.XmlDeclaration:
                        //Console.Write("<?xml version='1.0'?>");
                        break;
                    case XmlNodeType.Document:
                        break;
                    case XmlNodeType.DocumentType:
                        /// Console.Write("<!DOCTYPE {0} [{1}]", this.xml.Name, this.xml.Value);
                        break;
                    case XmlNodeType.EntityReference:
                        //  Console.Write(this.xml.Name);
                        break;
                    case XmlNodeType.EndElement:
                        // Console.Write("</{0}>", this.xml.Name);
                        break;
                }
                // Console.Write("\nname:{0},value:{1}\n",this.xml.Name,this.xml.Value);
            }
        }

        protected void prase1(XmlReader mm, string dd)
        {
            //SortedDictionary<string, string> mn = new SortedDictionary<string, string>();
            //int i = 0;
            mm.MoveToContent();
            string ff = "";
            while (mm.Read())
            {

                switch (mm.NodeType)
                {
                    case XmlNodeType.Element:
                        // Console.Write("<{0}>", ff = this.xml.Name);
                        ff = this.xml.Name;
                        break;
                    case XmlNodeType.Text:
                        {
                            Console.Write("{0} {1}", this.xml.Name, this.xml.Value);

                            //mm.Read();
                            this.mm.Add(ff, mm.Value);
                        }
                        break;
                }

            }
            // this.mdata.Add(dd, mn);

        }

        public string getdata(string k)
        {

            // this.mm = this.mdata[k];




            return this.mm[k];

        }
        public void close()
        {

            this.xml.Close();


        }






    }



 public class xmlwrite
    {

        public string name;
        public string error;
        public string hand_type;
        public XmlWriter xml;
        //  public XmlWriterSettings jk;
        protected SortedDictionary<string, SortedDictionary<string, string>> mdata;
        protected SortedDictionary<string, string> mm;
        public xmlwrite()
        {
            this.name = "";
            this.error = "";
            this.hand_type = "";



        }
        public void init(string f)
        {
            this.xml = XmlWriter.Create(f);


        }
        public void init(Stream ff)
        {

            this.xml = XmlWriter.Create(ff);

        }
        public void init(StringBuilder k)
        {

            this.xml = XmlWriter.Create(k);
        }

        public void setmdata(SortedDictionary<string, SortedDictionary<string, string>> fg)
        {

            this.mdata = fg;


        }
        public void setdata(SortedDictionary<string, string> gf)
        {

            this.mm = gf;

        }

        public void prase()
        {

            this.xml.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
            this.xml.WriteStartElement("root");
            this.xml.WriteStartElement("hand");
            this.xml.WriteElementString("name", this.name);
            this.xml.WriteElementString("error", this.error);
            this.xml.WriteElementString("hand_type", this.hand_type);
            this.xml.WriteEndElement();
            this.xml.WriteStartElement("body");
            foreach (KeyValuePair<string, SortedDictionary<string, string>> kvp in this.mdata)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                    kvp.Key, kvp.Value);
                this.xml.WriteStartElement(kvp.Key);
                foreach (KeyValuePair<string, string> hg in kvp.Value)
                {


                    this.xml.WriteElementString(hg.Key, hg.Value);



                }
                this.xml.WriteEndElement();


            }
            this.xml.WriteEndElement();//body
            this.xml.WriteEndElement();//root

            this.xml.Flush();

        }


        public void prase_float(SortedDictionary<float, SortedDictionary<float, user_work>> k)
        {

            this.xml.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
            this.xml.WriteStartElement("root");
            this.xml.WriteStartElement("hand");
            this.xml.WriteElementString("name", this.name);
            this.xml.WriteElementString("error", this.error);
            this.xml.WriteElementString("hand_type", this.hand_type);
            this.xml.WriteEndElement();
            this.xml.WriteStartElement("body");
            foreach (KeyValuePair<float, SortedDictionary<float, user_work>> kvp in k)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                    kvp.Key, kvp.Value);
                if (kvp.Value != null)
                {
                    int ff = 0;
                    foreach (KeyValuePair<float, user_work> hg in kvp.Value)
                    {
                        this.xml.WriteStartElement("un" + ff);

                        this.xml.WriteElementString("name00", hg.Value.getname());
                        this.xml.WriteElementString("data00", hg.Value.data);
                        this.xml.WriteElementString("link100", hg.Value.link);
                        this.xml.WriteElementString("time00", "2012");
                        this.xml.WriteEndElement();

                        ff++;
                    }



                }
                else
                {

                    this.xml.WriteStartElement("un0");

                    this.xml.WriteElementString("name00", "return");
                    this.xml.WriteElementString("title00", "kong");
                    this.xml.WriteElementString("link100", "4");
                    this.xml.WriteElementString("time00", "2012");
                    this.xml.WriteEndElement();

                    break;




                }




            }
            this.xml.WriteEndElement();//body
            this.xml.WriteEndElement();//root

            this.xml.Flush();

        }

        public void prase_float_shop(SortedDictionary<float, SortedDictionary<float, shop_base>> k)
        {

            this.xml.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
            this.xml.WriteStartElement("root");
            this.xml.WriteStartElement("hand");
            this.xml.WriteElementString("name", this.name);
            this.xml.WriteElementString("error", this.error);
            this.xml.WriteElementString("hand_type", this.hand_type);
            this.xml.WriteEndElement();
            this.xml.WriteStartElement("body");


            int gg = 0;
            foreach (KeyValuePair<float, SortedDictionary<float, shop_base>> kvp in k)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                    kvp.Key, kvp.Value);
                if (kvp.Value != null)
                {
                    foreach (KeyValuePair<float, shop_base> hg in kvp.Value)
                    {
                        this.xml.WriteStartElement("un" + gg);

                        this.xml.WriteElementString("name00", hg.Value.aname);//名称
                        this.xml.WriteElementString("price00", hg.Value.price.ToString());//描述
                        this.xml.WriteElementString("shop_link00", hg.Value.shop_link);//商品链接
                        this.xml.WriteElementString("assortment100", hg.Value.assortment1);
                        this.xml.WriteElementString("assortment200", hg.Value.assortment2);
                        this.xml.WriteElementString("assortment300", hg.Value.assortment3);
                        this.xml.WriteElementString("brand00", hg.Value.brand);
                        this.xml.WriteElementString("prices00", hg.Value.prices);
                        this.xml.WriteElementString("freeshipping00", hg.Value.freeshipping.ToString());
                        this.xml.WriteElementString("newshop00", hg.Value.newshop.ToString());
                        this.xml.WriteElementString("salse00", hg.Value.salse.ToString());
                        this.xml.WriteElementString("praise00", hg.Value.praise.ToString());
                        this.xml.WriteElementString("follow00", hg.Value.follow.ToString());
                        //this.xml.WriteElementString("link", hg.Value.shop_link);
                        this.xml.WriteEndElement();
                        gg++;

                    }


                }
                else
                {

                    this.xml.WriteStartElement("un0");

                    this.xml.WriteElementString("name00", "return");
                    this.xml.WriteElementString("title00", "kong");
                    this.xml.WriteElementString("type00", "4");
                    this.xml.WriteEndElement();

                    break;








                }
            }
            this.xml.WriteEndElement();//body
            this.xml.WriteEndElement();//root

            this.xml.Flush();

        }
        public void prase_j()
        {
            this.xml.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8'");
            this.xml.WriteStartElement("root");
            this.xml.WriteStartElement("hand");
            this.xml.WriteElementString("name", this.name);
            this.xml.WriteElementString("error", this.error);
            this.xml.WriteElementString("hand_type", this.hand_type);
            this.xml.WriteEndElement();
            this.xml.WriteStartElement("body");
            foreach (KeyValuePair<string, string> kvp in this.mm)
            {

                this.xml.WriteElementString(kvp.Key, kvp.Value);

            }
            this.xml.WriteEndElement();//body
            this.xml.WriteEndElement();//root

            this.xml.Flush();


        }

        public void close()
        {

            this.xml.Close();


        }


    }

 public class xml_writer
    {


        private string result;
        private string xml_hand;
        public xml_writer()
        {


            this.result = "<?xml version='1.0' encoding='utf-8'?>";

        }

        public string startelement(string mf)
        {

            return this.result += "<" + mf + ">";




        }
        public string endelement(string mg)
        {

            return this.result += "</" + mg + ">";
        }

        public string writeelementstring(string mm, string ff)
        {



            return this.result += "<" + mm + ">" + ff + "</" + mm + ">";


        }
        public string getresult()
        {


            return this.result;



        }



    }

}
