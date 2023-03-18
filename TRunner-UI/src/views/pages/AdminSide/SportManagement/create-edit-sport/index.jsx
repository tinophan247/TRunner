import React, { useEffect, useState } from 'react';
import SingleSelect from '../../../../components/Dropdown/single-select';
import TextFields from '../../../../components/TextField';
import '../../../../../styles/tooltip.css';
import UploadImage from '../../../../components/UploadImage';
import { activeDatas, defautSport, sportTypeDatas } from '../../../../../constants';
import ModalConfirm from '../../../../components/ModalConfirm';

const CreateEditSport = ({ onClose, isCreate, data }) => {
  const [showModal, setShowModal] = useState(false);
  const [formState, setFormState] = useState(defautSport);
  const [validForm, setValidForm] = useState({
    sportName: true,
    sportType: true,
    active: true
  });

  const validateForm = () => {
    let isValid = true;

    Object.keys(validForm).forEach(x => {
      if (!formState[x] || formState[x].value <= 0) {
        {
          isValid = false;
          validForm[x] = false;
        }
      }
    });

    if (!isValid) {
      setValidForm({ ...validForm });
      return false;
    }
    return true;
  };

  const handleSubmitForm = e => {
    if (e) {
      e.preventDefault();
    }

    if (!validateForm()) {
      return;
    }
  };

  const handleClose = () => {
    setShowModal(false);
  };

  const handleChangeSportName = event => {
    setFormState({
      ...formState,
      sportName: event.target.value
    });
    setValidForm({ ...validForm, sportName: !!event.target.value });
  };

  const handleChangeSportType = event => {
    setFormState({
      ...formState,
      sportType: event.target.value
    });
    setValidForm({ ...validForm, sportType: true });
  };

  const handleChangeActive = event => {
    setFormState({
      ...formState,
      active: event.target.value
    });
    setValidForm({ ...validForm, active: true });
  };

  const handleSave = () => {
    if (!validateForm()) {
      return;
    }
    setShowModal(true);
  };

  useEffect(() => {
    setFormState({ ...data });
  }, [data]);

  useEffect(() => {
    setValidForm({ ...validForm });
  }, []);

  return (
    <div>
      <form onSubmit={handleSubmitForm}>
        <div className='font-barlow font-semibold	flex'>
          <p className='text-ct4-dark-green text-base uppercase cursor-pointer font-barlow' onClick={() => onClose()}>
            Sports
          </p>
          <div className='mx-3 text-base text-ct4-gray'>
            <i className='fa-solid fa-chevron-right'></i>
          </div>
          <p className='text-ct4-gray-3 text-base uppercase'>{isCreate ? 'Create a New Sport' : 'Edit Sport'}</p>
        </div>
        <div className='mt-5 flex justify-between'>
          <p className='font-barlow font-semibold uppercase text-28'>
            {isCreate ? 'Create a New Sport' : 'Edit Sport'}
          </p>
          <div>
            <button
              className='uppercase w-140 h-10 border border-ct4-border-gray font-barlow font-semibold text-sm rounded mr-3'
              onClick={() => onClose()}
            >
              Cancel
            </button>
            <button
              type='submit'
              className='uppercase w-140 h-10 bg-ct4-green-neon font-barlow font-semibold text-sm rounded'
              onClick={handleSave}
            >
              Save
            </button>
          </div>
        </div>
        <div className='flex items-center flex-col mt-8 gap-y-4'>
          <TextFields
            name='Sport Name'
            required={true}
            width='600px'
            placeholder={'Group Name'}
            value={formState.sportName}
            valid={validForm.sportName}
            onChange={handleChangeSportName}
          />
          <SingleSelect
            name='Sport Type'
            required={true}
            width='600px'
            options={sportTypeDatas}
            value={formState.sportType}
            valid={validForm.sportType}
            onChange={handleChangeSportType}
          />
          <SingleSelect
            name='Active'
            required={true}
            options={activeDatas}
            value={formState.active}
            onChange={handleChangeActive}
            valid={validForm.active}
          />
          <div className='w-600'>
            <UploadImage type='Sport Picture' img={formState.img} />
          </div>
        </div>
      </form>

      {showModal && (
        <ModalConfirm
          isShow={showModal}
          onClose={handleClose}
          onSave={() => onClose()}
          text='Are you sure you want to save it? This action cannot be undone.'
        />
      )}
    </div>
  );
};

export default CreateEditSport;
