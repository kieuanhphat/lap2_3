﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace baitap2.Models
{
    public class Book
    {
        private int id;
        private string title;
        private string author;
        private string image_cover;

        public Book()
        {                   

        }

        /*public Book(int id, string title, string author, string image_cover)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.image_cover = image_cover;
        }
        public int Id
        {
            get { return id; }
        }
        public string Title
        {
            get { return title; }
        }
        public string Author
        {
            get { return author; }
        }
        public string ImageCover
        {
            get { return image_cover; }
        }*/
        public Book(int id, string title, string author, string image_cover)
        {
            this.id = id;
            this.title = title;
            this.author = author;
            this.image_cover = image_cover;
        }
        [Required(ErrorMessage = "không được trống")]
        [Display(Name = "MÃ Sách ")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [Required(ErrorMessage = "Tiêu đề không được trống")]
        [StringLength(250, ErrorMessage = "Tiêu đề không vượt quá 250 ký tự")]
        [Display(Name = "Tiêu đề")]

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        [Display(Name = "Tác Giả ")]
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        [Display(Name = "Đường dẫn ảnh ")]
        public string ImageCover
        {
            get { return image_cover; }
            set { image_cover = value; }
        }
    }
}