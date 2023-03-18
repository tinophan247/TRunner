import { Checkbox } from '@mui/material';
import React, { useEffect, useState } from 'react';
import MultipleSelect from '../../../../components/Dropdown/multi-select';
import SingleSelect from '../../../../components/Dropdown/single-select';
import CheckedIcon from '../../../../components/Icons/checked-icon';
import TextFields from '../../../../components/TextField';
import '../../../../../styles/tooltip.css';
import UploadImage from '../../../../components/UploadImage';
import { activeDatas, defaultGroup, groupTypeDatas } from '../../../../../constants';
import HelpMenuIcon from '../../../../components/Icons/help-menu-icon';
import ModalConfirm from '../../../../components/ModalConfirm';
import TextArea from '../../../../components/TextArea/index';

const CreateEditGroup = ({ onClose, isCreate, data }) => {
  const [showModal, setShowModal] = useState(false);
  const [formState, setFormState] = useState(defaultGroup);
  const [validForm, setValidForm] = useState({
    groupName: true,
    location: true,
    groupType: true,
    sport: true,
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
            Groups
          </p>
          <div className='mx-3 text-base text-ct4-gray'>
            <i className='fa-solid fa-chevron-right'></i>
          </div>
          <p className='text-ct4-gray-3 text-base uppercase'>{isCreate ? 'Create a New Group' : 'Edit Group'}</p>
        </div>
        <div className='mt-5 flex justify-between'>
          <p className='font-barlow font-semibold uppercase text-28'>
            {isCreate ? 'Create a New Group' : 'Edit Group'}
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
        <div className='mt-8 flex'>
          <div className='grid gap-y-4'>
            <TextFields
              name='Group Name'
              required={true}
              placeholder={'Group Name'}
              value={formState.groupName}
              onChange={e => {
                setFormState({
                  ...formState,
                  groupName: e.target.value
                });
                setValidForm({ ...validForm, groupName: !!e.target.value });
              }}
              valid={validForm.groupName}
            />
            <TextArea
              name='Description'
              placeholder={'Description'}
              value={formState.desc}
              onChange={e => {
                setFormState({
                  ...formState,
                  desc: e.target.value
                });
              }}
            />
            <TextFields
              name='Location'
              required={true}
              placeholder={'Location'}
              value={formState.location}
              onChange={e => {
                setFormState({
                  ...formState,
                  location: e.target.value
                });
                setValidForm({ ...validForm, location: !!e.target.value });
              }}
              valid={validForm.location}
            />
            <TextFields
              name='Website'
              placeholder={'Website'}
              value={formState.website}
              onChange={e => {
                setFormState({
                  ...formState,
                  website: e.target.value
                });
              }}
            />
            <SingleSelect
              name='Group Type'
              required={true}
              options={groupTypeDatas}
              value={formState.groupType}
              onChange={e => {
                setFormState({
                  ...formState,
                  groupType: e.target.value
                });
                setValidForm({ ...validForm, groupType: true });
              }}
              valid={validForm.groupType}
            />
            <MultipleSelect
              name='Sport'
              width='600px'
              required={true}
              value={formState.sport}
              onChange={e => {
                setFormState({
                  ...formState,
                  sport: e.target.value
                });
                setValidForm({ ...validForm, sport: true });
              }}
              valid={validForm.sport}
            />
            <SingleSelect
              name='Active'
              required={true}
              options={activeDatas}
              value={formState.active}
              onChange={e => {
                setFormState({
                  ...formState,
                  active: e.target.value
                });
                setValidForm({ ...validForm, active: true });
              }}
              valid={validForm.active}
            />
            <div className='-ml-3 font-barlow flex items-center'>
              <Checkbox checkedIcon={<CheckedIcon />} />
              <p className='mr-2'>Make your club invite-only?</p>
              <div className='tooltip cursor-pointer'>
                <HelpMenuIcon />
                <span className='tooltiptext-help-icon font-barlow px-6 pt-4 pb-6'>
                  <div className='flex '>
                    <HelpMenuIcon stroke='#ffffff' />
                    <p className='font-semibold text-14 ml-2'>Invite-Only Group</p>
                  </div>
                  <div className='mt-4 '>
                    <p>Runners must request permission to join an invite-only Group.</p>
                    <p className='mt-4'>
                      Only admins can approve new Group members. Recent activity, club announcements, discussions and
                      private group events will be hidden from non-members.
                    </p>
                  </div>
                </span>
              </div>
            </div>
          </div>
          <UploadImage type='Group Picture' img={formState.img} />
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

export default CreateEditGroup;
