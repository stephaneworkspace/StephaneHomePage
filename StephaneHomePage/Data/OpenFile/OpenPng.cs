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
    public class OpenPng
    {
        private string _file { get; set; }
        private byte [] _pngRaw { get; set; }
        public bool SwStatus { get; set; }
        public string ErrMessage { get; set; }
        public string ErrTitle { get; set; }
        public OpenPng(string s)
        {
            this._file = s;
            //this._pngRaw = [];
            this.SwStatus = false;
            this.ErrMessage = "";
            this.ErrTitle = "Erreur de chargement png: " + this._file;
        }
        public void LoadPngB64()
        {
            try
            {
                this._pngRaw = System.IO.File.ReadAllBytes(this._file);
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
        public String getPng()
        {
            return Convert.ToBase64String(this._pngRaw);
        }
    }
}
