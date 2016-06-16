using System;
using Android.Content;
using Android.Runtime;
using Android.Util;
using FFImageLoading;
using FFImageLoading.Views;
using FFImageLoading.Work;
using System.Threading.Tasks;
using Java.IO;

namespace TechTalk.Droid.Controls
{
    public class CacheImageView : ImageViewAsync
    {
        #region Private fields

        private string _imageUrl;
        private ITransformation _transformation;

        #endregion

        #region Properties

        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
                LoadImage(value);
            }
        }

        public ITransformation Transformation
        {
            get { return _transformation; }
            set
            {
                _transformation = value;
                LoadImage(ImageUrl);
            }
        }

        #endregion

        #region Ctors

        public CacheImageView(Context context)
            : base(context)
        {
            Initialize(context);
        }

        public CacheImageView(Context context, IAttributeSet attrs)
            : base(context, attrs)
        {
            Initialize(context, attrs);
        }

        protected CacheImageView(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        #endregion

        #region Protected methods

        protected void Initialize(Context context, IAttributeSet attributes = null)
        {
            ApplyBinding(context, attributes);
        }

        #endregion

        #region Private methods

        private void ApplyBinding(Context context, IAttributeSet attrs = null)
        {
            var typedArray = context.ObtainStyledAttributes(attrs, new[] { Android.Resource.Attribute.Src });
            var numStyles = typedArray.IndexCount;
            for (var i = 0; i < numStyles; ++i)
            {
                var attributeId = typedArray.GetIndex(i);
                if (attributeId == Android.Resource.Attribute.Src)
                {
                    ImageUrl = typedArray.GetString(attributeId);
                }
            }
            typedArray.Recycle();
        }

        private void LoadImage(string imageUri)
        {
            if (string.IsNullOrEmpty(imageUri))
            {
                return;
            }
            var request = ImageService.Instance.LoadFile(imageUri);
            if (_transformation != null)
            {
                request = request.Transform(_transformation);
            }
            request.Into(this);
        }

        #endregion
    }
}