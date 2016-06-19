package com.epam.techtalk;

oneway interface IGalleryServiceProxy
{
    void loadImagesAsync();
	void registerCallback(IGalleryServiceCallbackProxy callback);
}