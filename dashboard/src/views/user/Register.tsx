import React from 'react'
import {
  CButton,
  CCard,
  CCardBody,
  CCardFooter,
  CCol,
  CContainer,
  CForm,
  CInput,
  CInputGroup,
  CInputGroupPrepend,
  CInputGroupText,
  CRow,
  CSelect
} from '@coreui/react'
import CIcon from '@coreui/icons-react'
import { Field, Formik } from 'formik'
import { useUser } from '../../providers/UserProvider'
import { useHistory } from 'react-router-dom'

const Register = () => {
  const { register } = useUser();
  const history = useHistory();

  return (
    <div className="c-app c-default-layout flex-row align-items-center">
      <CContainer>
        <CRow className="justify-content-center">
          <CCol md="9" lg="7" xl="6">
            <CCard className="mx-4">
              <CCardBody className="p-4">
                <Formik
                  initialValues={{username: '', password: '', role: 'Manager'}}
                  onSubmit={async (values, { setSubmitting }) => {
                    console.log('Submit')
                    let user = await register(values.username, values.password, values.role);
                    if (user) {
                      history.push('/')
                    }
                    // setTimeout(() => {
                    //   alert(JSON.stringify(values, null, 2));
                    //   setSubmitting(false);
                    // }, 400);
                  }}
                >
                {({isSubmitting, submitForm}) => (
                  <CForm>
                    <h1>Register</h1>
                    <p className="text-muted">Create your account</p>
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
                    <CInputGroup className="mb-3">
                      <CInputGroupText>
                        <CIcon name="cil-group"></CIcon>
                      </CInputGroupText>
                      <Field name="role">
                        {({field}: {field: any}) => (
                          <CSelect {...field} placeholder="Role" autoComplete="email" disabled={isSubmitting}>
                            <option>Manager</option>
                            <option>Trader</option>
                            <option>Developer</option>
                        </CSelect>
                        )}
                      </Field>
                    </CInputGroup>
                    <CInputGroup className="mb-3">
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
                    {/* <CInputGroup className="mb-4">
                      <CInputGroupPrepend>
                        <CInputGroupText>
                          <CIcon name="cil-lock-locked" />
                        </CInputGroupText>
                      </CInputGroupPrepend>
                      <CInput type="password" placeholder="Repeat password" autoComplete="new-password" disabled={isSubmitting}/>
                    </CInputGroup> */}
                    <CButton color="success" block disabled={isSubmitting} onClick={submitForm}>Create Account</CButton>
                  </CForm>
                )}
                </Formik>
              </CCardBody>
            </CCard>
          </CCol>
        </CRow>
      </CContainer>
    </div>
  )
}

export default Register
