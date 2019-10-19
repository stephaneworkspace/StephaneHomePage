using StephaneHomePage.Data.Type;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace StephaneHomePage.Data.OpenFile
{
    public class OpenSvg
    {
        private string _file { get; set; }
        private string _svgRaw { get; set; }
        public bool SwStatus { get; set; }
        public string ErrMessage { get; set; }
        public OpenSvg(string s)
        {
            this._file = s;
            this._svgRaw = "";
            this.SwStatus = false;
            this.ErrMessage = "";
        }
        public void LoadSvgB64()
        {
            try
            {
                this._svgRaw = System.IO.File.ReadAllText(this._file);
                this.ErrMessage = "";
                this.SwStatus = true;
            }
            catch (ArgumentNullException e)
            {
                this.SwStatus = false;
                this.ErrMessage = e.ToString();
            }
            catch (ArgumentException e)
            {
                this.SwStatus = false;
                this.ErrMessage = e.ToString();
            }
            catch (PathTooLongException e)
            {
                this.SwStatus = false;
                this.ErrMessage = e.ToString();
            }
            catch (DirectoryNotFoundException e)
            {
                this.SwStatus = false;
                this.ErrMessage = e.ToString();
            }
            catch (FileNotFoundException e)
            {
                this.SwStatus = false;
                this.ErrMessage = e.ToString();
            }
            catch (IOException e)
            {
                this.SwStatus = false;
                this.ErrMessage = e.ToString();
            }
            catch (UnauthorizedAccessException e)
            {
                this.SwStatus = false;
                this.ErrMessage = e.ToString();
            }
            catch (NotSupportedException e)
            {
                this.SwStatus = false;
                this.ErrMessage = e.ToString();
            }
            catch (SecurityException e)
            {
                this.SwStatus = false;
                this.ErrMessage = e.ToString();
            }
        }
        public Svg getSvg()
        {
            return new Svg(Convert.ToBase64String(ASCIIEncoding.UTF8.GetBytes(this._svgRaw)));
        }
    }
}
