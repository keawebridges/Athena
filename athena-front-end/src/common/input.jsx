import React from "react";
const Input = ({ name, label, value, onChange, placeholder }) => {
  return (
    <div className="form-group">
      <label htmlFor={name}>{label}</label>
      <input
        value={value}
        onChange={onChange}
        id={name}
        name={name}
        type="text"
        className="form-control"
        placeholder={placeholder}
      />
    </div>
  );
};

export default Input;
