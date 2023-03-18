import React, { useEffect, useState } from 'react';
import { modalConfirmStyle } from './style';
import CloseIcon from '@mui/icons-material/Close';
import { Box, Modal } from '@mui/material';

const ModalConfirm = ({ isShow = 'false', onClose, onSave, text, cancelLabel = 'Cancel', confirmLabel = 'Save' }) => {
  const [open, setOpen] = useState(isShow);

  useEffect(() => {
    setOpen(isShow);
  }, [isShow]);

  return (
    <div>
      <Modal open={open}>
        <Box sx={modalConfirmStyle}>
          <div className='flex justify-end cursor-pointer '>
            <CloseIcon onClick={() => onClose()} />
          </div>
          <p className='text-sm font-barlow mt-4'>{text}</p>
          <div className='flex justify-end mt-8'>
            <button
              className='uppercase w-120 h-10 border border-ct4-border-gray font-barlow font-bold text-sm rounded mr-3'
              onClick={() => onClose()}
            >
              {cancelLabel}
            </button>
            <button
              className='uppercase w-120 h-10 bg-ct4-green-neon font-barlow font-bold text-sm rounded'
              onClick={() => onSave()}
            >
              {confirmLabel}
            </button>
          </div>
        </Box>
      </Modal>
    </div>
  );
};

export default ModalConfirm;
