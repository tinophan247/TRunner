const createRoleData = role => {
  return { role };
};

export const roleDatas = [
  createRoleData('Super Admin'),
  createRoleData('Admin'),
  createRoleData('Coach'),
  createRoleData('Member'),
  createRoleData('Customer Service')
];

//fake data group list
const createDataGroups = (
  groupName,
  desc,
  location,
  sport,
  groupType,
  createdDate,
  totalRunners,
  active,
  website,
  checkbox,
  img
) => {
  return { groupName, desc, location, sport, groupType, createdDate, totalRunners, active, website, checkbox, img };
};

export const groupData = [
  createDataGroups(
    'Group A',
    'We are the one. We ride, we run',
    'Hà Nội',
    ['Run'],
    'Company/Workplace',
    '01/15/2023',
    200,
    'Enabled',
    'https://www.tma.vn/',
    true,
    'https://kingscampsandfitness.com/wp-content/uploads/2016/06/Trail-Running-Square.jpg'
  ),
  createDataGroups(
    'Group B',
    'Enjoy the moment that your',
    'Hà Nam',
    ['Row'],
    'Other',
    '01/07/2023',
    178,
    'Enabled',
    'https://www.tma.vn/',
    true,
    'https://img.freepik.com/premium-vector/badminton-rackets-flat-square-icon-with-shadows_47586-1.jpg'
  ),
  createDataGroups(
    'Group C',
    'No description',
    'Hải Dương',
    ['Run', 'Ride'],
    'Racing Team',
    '12/21/2022',
    23,
    'Disabled',
    '',
    false,
    'https://img.freepik.com/free-psd/reasons-ride-bike-ad-template-square-flyer_23-2148755171.jpg'
  ),
  createDataGroups(
    'Group A',
    'We are the one. We ride, we run',
    'Hà Nội',
    ['Run'],
    'Company/Workplace',
    '01/15/2023',
    200,
    'Enabled',
    'https://www.tma.vn/',
    true,
    'https://kingscampsandfitness.com/wp-content/uploads/2016/06/Trail-Running-Square.jpg'
  ),
  createDataGroups(
    'Group B',
    'Enjoy the moment that your',
    'Hà Nam',
    ['Row'],
    'Other',
    '01/07/2023',
    178,
    'Enabled',
    'https://www.tma.vn/',
    true,
    'https://img.freepik.com/premium-vector/badminton-rackets-flat-square-icon-with-shadows_47586-1.jpg'
  ),
  createDataGroups(
    'Group C',
    'No description',
    'Hải Dương',
    ['Run', 'Ride'],
    'Racing Team',
    '12/21/2022',
    23,
    'Disabled',
    '',
    false,
    'https://img.freepik.com/free-psd/reasons-ride-bike-ad-template-square-flyer_23-2148755171.jpg'
  ),
  createDataGroups(
    'Group A',
    'We are the one. We ride, we run',
    'Hà Nội',
    ['Run'],
    'Company/Workplace',
    '01/15/2023',
    200,
    'Enabled',
    'https://www.tma.vn/',
    true,
    'https://kingscampsandfitness.com/wp-content/uploads/2016/06/Trail-Running-Square.jpg'
  ),
  createDataGroups(
    'Group B',
    'Enjoy the moment that your',
    'Hà Nam',
    ['Row'],
    'Other',
    '01/07/2023',
    178,
    'Enabled',
    'https://www.tma.vn/',
    true,
    'https://img.freepik.com/premium-vector/badminton-rackets-flat-square-icon-with-shadows_47586-1.jpg'
  ),
  createDataGroups(
    'Group C',
    'No description',
    'Hải Dương',
    ['Run', 'Ride'],
    'Racing Team',
    '12/21/2022',
    23,
    'Disabled',
    '',
    false,
    'https://img.freepik.com/free-psd/reasons-ride-bike-ad-template-square-flyer_23-2148755171.jpg'
  ),
  createDataGroups(
    'Group A',
    'We are the one. We ride, we run',
    'Hà Nội',
    ['Run'],
    'Company/Workplace',
    '01/15/2023',
    200,
    'Enabled',
    'https://www.tma.vn/',
    true,
    'https://kingscampsandfitness.com/wp-content/uploads/2016/06/Trail-Running-Square.jpg'
  ),
  createDataGroups(
    'Group B',
    'Enjoy the moment that your',
    'Hà Nam',
    ['Row'],
    'Other',
    '01/07/2023',
    178,
    'Enabled',
    'https://www.tma.vn/',
    true,
    'https://img.freepik.com/premium-vector/badminton-rackets-flat-square-icon-with-shadows_47586-1.jpg'
  ),
  createDataGroups(
    'Group C',
    'No description',
    'Hải Dương',
    ['Run', 'Ride'],
    'Racing Team',
    '12/21/2022',
    23,
    'Disabled',
    '',
    false,
    'https://img.freepik.com/free-psd/reasons-ride-bike-ad-template-square-flyer_23-2148755171.jpg'
  )
];

export const defaultGroup = {
  groupName: '',
  desc: '',
  location: '',
  sport: [],
  groupType: '',
  createdDate: '',
  totalRunners: 0,
  active: 'Enabled',
  website: '',
  checkbox: false,
  img: ''
};
//fake data location list
const createLocationData = value => {
  return { value };
};

export const locationDatas = [
  createLocationData('Hà Nội'),
  createLocationData('Hà Nam'),
  createLocationData('Hà Tĩnh'),
  createLocationData('Hải Dương'),
  createLocationData('Hải Phòng')
];

//fake data group type
const createGroupTypeData = value => {
  return { value };
};

export const groupTypeDatas = [
  createGroupTypeData('Racing Team'),
  createGroupTypeData('Company/Workplace'),
  createGroupTypeData('Club'),
  createGroupTypeData('Shop'),
  createGroupTypeData('Other')
];

//fake data active
const createActiveData = value => {
  return { value };
};

export const activeDatas = [createActiveData('Enabled'), createActiveData('Disabled')];

//fake data sport
const createDataSports = (sportName, sportType, lastModifiedBy, lastModifiedDate, active, img) => {
  return { sportName, sportType, lastModifiedBy, lastModifiedDate, active, img };
};

export const sportData = [
  createDataSports(
    'Canoe',
    'Water Sports',
    'Gloria Yort',
    '01/15/2023',
    'Disabled',
    'https://img.freepik.com/free-photo/kayaker-splashing-water-with-paddle-while-kayaking_23-2147870359.jpg?t=st=1676894132~exp=1676894732~hmac=1f19f77684ade20508ac7ffc5502d25091b2ab44af423dd679124466aeb65212'
  ),
  createDataSports(
    'CrossFit',
    'Other Sports',
    'Miranda Streich',
    '01/07/2023',
    'Disabled',
    'https://img.freepik.com/free-photo/close-up-man-doing-crossfit-workout_23-2149080469.jpg?t=st=1676894173~exp=1676894773~hmac=046baa5a28f8954542a50b426eb1068347194b7b3793c035e087e8bd264bd7ba'
  ),
  createDataSports(
    'E-Bike Ride',
    'Cycle Sports',
    'Kyle Baile',
    '01/12/2023',
    'Disabled',
    'https://img.freepik.com/free-photo/man-ride-bicycle-bridgethe-image-cyclist-motion-background-morning_654080-318.jpg?t=st=1676894215~exp=1676894815~hmac=39cf24201badfeb04a83b48c17522bb9766544e76fa6f08a99c1eaec94ba4e03'
  ),
  createDataSports(
    'Golf',
    'Other Sports',
    'Neil Mayert',
    '12/21/2022',
    'Disabled',
    'https://as1.ftcdn.net/v2/jpg/00/08/48/90/1000_F_8489083_gyFQj5QhX6ZpoH42Vwasg2ZCl1duhntD.jpg'
  ),
  createDataSports(
    'Run',
    'Foot Sports',
    'Deanna Daniel',
    '12/04/2022',
    'Enabled',
    'https://img.freepik.com/free-photo/young-fitness-woman-runner_1150-10576.jpg?t=st=1676894260~exp=1676894860~hmac=0e344a733bf082f38e2883e2cda7c910ad97f9715a278f642644d09b4e6451fe'
  ),
  createDataSports(
    'Ride',
    'Cycle Sports',
    'Gloria Yort',
    '01/01/2023',
    'Enabled',
    'https://img.freepik.com/free-photo/triathlon-male-athlete-cycle-training-isolated-white_155003-42571.jpg?t=st=1676894290~exp=1676894890~hmac=d52ea2dfd47361026eeee16d3d0e8220853df2514a2bb9c1577cd387f5f00e0a'
  ),
  createDataSports('Row', 'Water Sports', 'Gloria Yort', '12/19/2022', 'Enabled', ''),
  createDataSports('Sail', 'Water Sports', 'Deanna Daniel', '12/28/2022', 'Disabled', ''),
  createDataSports(
    'Skateboard',
    'Other Sports',
    'Deanna Daniel',
    '12/28/2022',
    'Disabled',
    'https://img.freepik.com/free-photo/attractive-cheerful-girl-with-skateboard-near-seaside-is-posing-photographer_613910-2754.jpg?w=1380&t=st=1676894374~exp=1676894974~hmac=97aee33ee32d1bff3c7e98cd825981f695f76e95f4159bbb92e0466b3d8e8e6c'
  ),
  createDataSports(
    'Surf',
    'Water Sports',
    'Gloria Yort',
    '12/28/2022',
    'Disabled',
    'https://img.freepik.com/free-photo/surfer-blue-wave_72229-1353.jpg?t=st=1676894414~exp=1676895014~hmac=a5d6f90ceb1df1172e8ca5226f923e3502a21635061e2a020c6df75b5444f4ba'
  ),
  createDataSports(
    'Swim',
    'Water Sports',
    'Gloria Yort',
    '12/28/2022',
    'Disabled',
    'https://img.freepik.com/premium-photo/fit-woman-swimming-pool_107420-5846.jpg?w=1380'
  ),
  createDataSports(
    'Walk',
    'Foot Sports',
    'Debra Klein',
    '12/28/2022',
    'Enabled',
    'https://img.freepik.com/free-photo/full-length-senior-sportsman-taking-walk-morning-listening-music-earphones-nature-copy-space_637285-3869.jpg?t=st=1676894499~exp=1676895099~hmac=376a20fb880837627565d2c91f7cad2554c2f365b1e63f4baeebce78e108f506'
  ),
  createDataSports(
    'Yoga',
    'Other Sports',
    'Gloria Yort',
    '12/28/2022',
    'Disabled',
    'https://img.freepik.com/free-photo/woman-stratching-isolated_1303-13963.jpg?w=1380&t=st=1676894541~exp=1676895141~hmac=b49e7261d39c4b9a73bba0c5e6f780fc96d8b696634812711742fcacf1701223'
  )
];

export const defautSport = {
  sportName: '',
  sportType: '',
  lastModifiedBy: '',
  lastModifiedDate: '',
  active: 'Enabled',
  img: ''
};

//fake data active
const createSportTypeData = value => {
  return { value };
};

export const sportTypeDatas = [
  createSportTypeData('Foot Sports'),
  createSportTypeData('Cycle Sports'),
  createSportTypeData('Water Sports'),
  createSportTypeData('Winter Sports'),
  createSportTypeData('Other Sports')
];

export const defaultGroupFilter = {
  location: '',
  sport: [],
  groupType: '',
  active: ''
}

export const defaultSportFilter = {
  sportType: '',
  active: ''
}

export const defaultGroupSort = {
  groupName: false,
  location: false,
  sport: false,
  groupType: false,
  createdDate: false,
  totalRunners: false,
  active: false
}

export const defaultSportSort = {
  sportName: false,
  sportType: false,
  lastModifiedBy: false,
  lastModifiedDate: false,
  active: false
}
