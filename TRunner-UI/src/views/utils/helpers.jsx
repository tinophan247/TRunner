export const checkSingleSelect = arr => {
  let sum = 0;
  for (let i = 0; i < arr.length; i++) {
    if (arr[i] !== '') {
      sum = sum + 1;
    }
  }
  return sum;
};

export const checkMultipleSelect = value => {
  if (value.length !== 0) {
    return 1;
  }
  return 0;
};
