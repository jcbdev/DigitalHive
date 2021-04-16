import React from 'react'
import { Link, useHistory } from 'react-router-dom'
import {
  CButton,
  CCard,
  CCardBody,
  CCardGroup,
  CCol,
  CContainer,
  CForm,
  CInput,
  CInputGroup,
  CInputGroupPrepend,
  CInputGroupText,
  CRow
} from '@coreui/react'
import CIcon from '@coreui/icons-react'
import { Field, Formik } from 'formik';
import { useUser } from '../../providers/UserProvider';

const Login = () => {
  const { login } = useUser();
  const history = useHistory();
  
  return (
    <div className="c-app c-default-layout flex-row align-items-center">
      <CContainer>
        <CRow className="justify-content-center">
          <CCol md="8">
            <CCardGroup>
              <CCard className="p-4">
                <CCardBody>
                  <Formik 
                    initialValues={{username: '', password: ''}}
                    onSubmit={async (values, { setSubmitting }) => {
                      console.log('Submit')
                      let user = await login(values.username, values.password);
                      if (user) {
                        console.log(user);
                        history.push("/dashboard");
                      }
                      // setTimeout(() => {
                      //   alert(JSON.stringify(values, null, 2));
                      //   setSubmitting(false);
                      // }, 400);
                    }}
                  >
                    {({isSubmitting, submitForm}) => (
                      <CForm>
                        <h1>Login</h1>
                        <p className="text-muted">Sign In to your account</p>
                        <CInputGroup className="mb-3">
                          <CInputGroupPrepend>
                            <CInputGroupText>
                              <CIcon name="cil-user" />
                            </CInputGroupText>
                          </CInputGroupPrepend>
                          <Field name="username">
                            {({field}: {field: any}) => (
                              <CInput {...field} type="text" placeholder="Username" autoComplete="username" disabled={isSubmitting}/>
                            )}
                          </Field>
                        </CInputGroup>
                        <CInputGroup className="mb-4">
                          <CInputGroupPrepend>
                            <CInputGroupText>
                              <CIcon name="cil-lock-locked" />
                            </CInputGroupText>
                          </CInputGroupPrepend>
                          <Field name="password">
                            {({field}: {field: any}) => (
                              <CInput {...field} type="text" placeholder="Password" autoComplete="password" disabled={isSubmitting}/>
                            )}
                          </Field>
                        </CInputGroup>
                        <CRow>
                          <CCol xs="6">
                            <CButton color="primary" className="px-4" disabled={isSubmitting} onClick={submitForm}>Login</CButton>
                          </CCol>
                        </CRow>
                      </CForm>  
                    )}
                  </Formik>
                </CCardBody>
              </CCard>
              <CCard className="text-white bg-primary py-5 d-md-down-none" style={{ width: '44%' }}>
                <CCardBody className="text-center">
                  <div>
                    <h2>Sign up</h2>
                    <p>Create a user on dashboard</p>
                    <Link to="/register">
                      <CButton color="primary" className="mt-3" active tabIndex={-1}>Register Now!</CButton>
                    </Link>
                  </div>
                </CCardBody>
              </CCard>
            </CCardGroup>
          </CCol>
        </CRow>
      </CContainer>
    </div>
  )
}

export default Login
