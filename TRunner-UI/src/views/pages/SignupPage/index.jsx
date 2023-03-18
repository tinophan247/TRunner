import React, { Component } from 'react';
import { connect } from 'react-redux';
import { Navigate, Link } from 'react-router-dom';
import FormInput from '../../components/FormInput';
import { authActions } from '../../../slices/authSlice';

class SignupPage extends Component {
    constructor(props) {
        super(props);
        this.handleSignup = this.handleSignup.bind(this);
        this.changeEmail = this.changeEmail.bind(this);
        this.changePassword = this.changePassword.bind(this);
        this.handleClickShowPassword = this.handleClickShowPassword.bind(this);
        this.state = {
            email: '',
            password: '',
            isRegister: false,
            isHide: false,
            error: false,
        };
    }

    Email = '';

    changeEmail(event) {
        const value = event.target.value;
        this.setState({ email: value });

        this.Email = value;
    }

    changePassword(event) {
        const value = event.target.value;
        this.setState({ password: value });
    }

    handleSignup(e) {
        e.preventDefault();
        this.props.onSignUp({ email: this.Email });
    }

    handleClickShowPassword() {
        this.setState({ isHide: !this.state.isHide });
    }

    render() {
        return (
            <div className='max-w-500 m-auto py-240 font-tnr'>
                <div className='text-center leading-5 uppercase text-2xl font-bold'>
                    <h1>Sign up with email</h1>
                </div>
                <form onSubmit={this.handleSignup}>
                    <FormInput
                        email={this.state.email}
                        password={this.state.password}
                        changeEmail={this.changeEmail}
                        changePassword={this.changePassword}
                        error={this.state.error}
                        isHide={this.state.isHide}
                        onClick={this.handleClickShowPassword}
                        isRegister={true}
                    />
                    <div className='text-base mt-2 leading-7'>
                        <span> By siging up you are agreeing to our{' '}
                            <Link to='/' className='underline'> Ters of Service.</Link>
                        </span>
                        <br />
                        <span>
                            View our{' '}
                            <Link to='/' className='underline'> Privacy Policy.</Link>
                        </span>
                    </div>
                    <div>
                        <button
                            type='submit'
                            className='btn mt-4 text-black bg-gray-300 font-bold rounded-sm text-base'
                        >
                            Agree and Sign Up
                        </button>
                        {this.props.isLoggedIn && <Navigate to='/dashboard' replace={true} />}
                    </div>

                </form>
            </div>
        );
    }
}

const mapStateToProps = state => {
    return {
        isLoggedIn: state.auth.isLoggedIn
    }
}

const mapDispatchToProps = (dispatch) => {
    return {
        onSignUp: (payload) => dispatch(authActions.signUp(payload))
    };
};

export default connect(mapStateToProps, mapDispatchToProps)(SignupPage);