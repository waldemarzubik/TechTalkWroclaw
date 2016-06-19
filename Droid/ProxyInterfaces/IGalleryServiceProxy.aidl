package com.epam.techtalk;

import com.epam.techtalk.IGalleryServiceCallbackProxy;

interface IGalleryServiceProxy
{
    void loadImagesAsync();
    void registerCallback(IGalleryServiceCallbackProxy callbackProxy);
}