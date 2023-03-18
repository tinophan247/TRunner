import React, { useEffect, useState } from 'react';
import CameraIcon from '../Icons/camera-icon';
import RecycleBinIcon from '../Icons/recycle-bin-icon';
import UploadImageIcon from '../Icons/upload-image-icon';

const UploadImage = ({ type, img }) => {
  const [selectedImage, setSelectedImage] = useState(null);
  const [image, setImage] = useState('');

  const handleDragOver = event => {
    event.preventDefault();
  };

  const handleDrop = event => {
    event.preventDefault();
    setSelectedImage(event.dataTransfer.files[0]);
  };

  const handleChange = event => {
    event.preventDefault();
    setSelectedImage(event.target.files[0]);
  };

  const handleRemove = () => {
    setSelectedImage(null);
    setImage('');
  };

  useEffect(() => {
    setImage(img);
  }, [img]);

  const renderImage = () => {
    return (
      <div>
        <img alt='not found' className='w-200 h-200' src={selectedImage ? URL.createObjectURL(selectedImage) : image} />
        <br />
        <div className='flex justify-center'>
          <div>
            <label htmlFor='dropzone-file'>
              <div className='flex items-center cursor-pointer'>
                <CameraIcon />
                <p className='ml-1 uppercase font-barlow font-semibold text-ct4-dark-green'>Change</p>
              </div>
              <input id='dropzone-file' type='file' className='hidden' accept='image/*' onChange={handleChange} />
            </label>
          </div>
          <div className='mx-5'>|</div>
          <div className='flex items-center cursor-pointer' onClick={handleRemove}>
            <RecycleBinIcon />
            <button className='ml-1 uppercase font-barlow font-semibold text-ct4-dark-green'>Remove</button>
          </div>
        </div>
      </div>
    );
  };

  const renderUploadField = () => {
    return (
      <label
        htmlFor='dropzone-file'
        onDragOver={handleDragOver}
        onDrop={handleDrop}
        className='flex flex-col items-center justify-center w-600 h-400 border-2 border-gray-300 border-dashed rounded-lg cursor-pointer bg-gray-50 dark:hover:bg-bray-800 dark:bg-gray-700 hover:bg-gray-100 dark:border-gray-600 dark:hover:border-gray-500 dark:hover:bg-gray-600'
      >
        <div className='flex flex-col items-center justify-center pt-5 pb-6'>
          <UploadImageIcon />
          <p className='mt-6 font-barlow text-ct4-gray-3'>Maximum size is 2MB</p>
          <div className='flex gap-x-1 mt-4'>
            <p className='font-barlow underline text-ct4-dark-green'>Click to upload</p>
            <p>or drag and drop.</p>
          </div>
        </div>
        <input id='dropzone-file' type='file' className='hidden' accept='image/*' onChange={handleChange} />
      </label>
    );
  };

  return (
    <div className={`text-base font-barlow-regular ${type === 'Sport Picture' ? '' : 'ml-16'}`}>
      <p>{type}</p>
      <div className='flex items-left w-full mt-2'>{selectedImage || image ? renderImage() : renderUploadField()}</div>
    </div>
  );
};

export default UploadImage;
