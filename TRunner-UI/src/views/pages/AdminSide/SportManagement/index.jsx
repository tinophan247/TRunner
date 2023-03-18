import React, { useEffect, useState } from 'react';
import PageLayout from '../../../components/PageLayout';
import { defautSport } from '../../../../constants';
import CreateEditSport from './create-edit-sport';
import ListSport from './list-sport/index';

const SportManagement = () => {
  const [isCreate, setIsCreated] = useState(false);
  const [isEdit, setIsEdit] = useState(false);
  const [sport, setSport] = useState(defautSport);
  const [isLoading, setIsLoading] = useState(false);

  const handleClose = () => {
    setIsCreated(false);
    setIsEdit(false);
    setSport(defautSport);
  };

  const handleCreate = () => {
    setIsCreated(true);
  };

  const handleEdit = item => {
    setSport({
      sportName: item.sportName,
      sportType: item.sportType,
      active: item.active,
      img: item.img
    });
    setIsEdit(true);
  };

  useEffect(() => {
    if (isLoading) {
      setTimeout(() => {
        setIsLoading(false);
      }, 1000);
    }
  }, [isLoading]);

  return (
    <>
      <PageLayout>
        {isCreate || isEdit ? (
          <CreateEditSport onClose={handleClose} isCreate={isCreate} data={sport} />
        ) : (
          <ListSport handleEdit={handleEdit} handleCreate={handleCreate} isloading={isLoading} />
        )}
      </PageLayout>
    </>
  );
};

export default SportManagement;
