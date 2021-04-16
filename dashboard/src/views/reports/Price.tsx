import React, { useEffect, useState } from 'react'
import {
  CCard,
  CCardBody,
  CCardGroup,
  CCardHeader,
  CSelect
} from '@coreui/react'
import {
  CChartLine,
} from '@coreui/react-chartjs'
import { getCommodityModels, getTimeSeries } from '../../services/reports';
import moment from 'moment';
import { Field, Formik } from 'formik';
import randomColor from 'randomcolor';
// import { DocsLink } from 'src/reusable'

const Charts = () => {
  const [data, setData] = useState<any>({
    datasets: [],
    labels: [],
  })
  const [model, setModel] = useState<string>("All");
  const [commodity, setCommodity] = useState<string>("All");

  const initialValues = {model: model, commodity: commodity};

  const updateGraphs = async (values: { model: string, commodity: string}, { setSubmitting }: {setSubmitting: (submit: boolean) => void}) => {
    setSubmitting(true);
    const result = await getCommodityModels(values.model === "All" ? null : values.model, values.commodity === "All" ? null : values.commodity);
    setChartData(result);
    setCommodity(commodity)
    setModel(model);
  }

  const template = (label: string) => {
    const color = randomColor({luminosity: 'dark', format: 'rgba'});
    const lightColor = color.replace(/[^,]+(?=\))/, '0.1');
    const darkColor = color.replace(/[^,]+(?=\))/, '1');
    return {
      data: [],
      label: label,
      backgroundColor: lightColor,
      borderColor: color,
      borderCapStyle: 'butt',
      borderDash: [],
      borderDashOffset: 0.0,
      borderJoinStyle: 'miter',
      pointBorderColor: color,
      pointBackgroundColor: '#fff',
      pointBorderWidth: 1,
      pointHoverRadius: 5,
      pointHoverBackgroundColor: color,
      pointHoverBorderColor: darkColor,
      pointHoverBorderWidth: 2,
      pointRadius: 1,
      pointHitRadius: 10,
    }
  }

  const setChartData = (result: any) => {
    const chartData: any = {
      datasets: [],
      labels:[],
    };
    const labels: any = {};
    for (const row of result.rows as Array<any>) {
      const setTitle = `${row.model}-${row.commodity}`;
      if (!chartData.datasets.find((s: any) => s.label === setTitle)) {
        console.log('Missing dataset')
        chartData.datasets.push(template(setTitle));
      }
      const dataSet = chartData.datasets.find((s: any) => s.label === setTitle);
      labels[moment(row.date).format('DD MMM YY')] = {};
      dataSet.data.push(row.price);
    }
    chartData.labels = Object.keys(labels);

    setData(chartData);
  }

  useEffect(() => {
    const fetchData = async () => {
      const result = await getCommodityModels();
      setChartData(result);
    };
 
    fetchData();
  }, []);

  return (<>
    <CCardGroup className = "cols-1">
      <CCard width={'100%'}>
        <CCardHeader>
          Filters
        </CCardHeader>
        <CCardBody>
          <Formik
            enableReinitialize={true}
            initialValues={initialValues}
            onSubmit={updateGraphs}
          >
            {({isSubmitting, submitForm}) => (<>
              <Field name="model">
                {({field}: {field: any}) => (
                  <CSelect {...field} placeholder="Role" autoComplete="email" disabled={isSubmitting} onBlur={submitForm}>
                    <option>All</option>
                    <option>Model1</option>
                    <option>Model2</option>
                </CSelect>)}
              </Field>
              <Field name="commodity">
                {({field}: {field: any}) => (
                  <CSelect {...field} placeholder="Role" autoComplete="email" disabled={isSubmitting} onBlur={submitForm}>
                    <option>All</option>
                    <option>Commodity1</option>
                    <option>Commodity2</option>
                </CSelect>)}
              </Field>
              </>)}
          </Formik>
        </CCardBody>
      </CCard>
    </CCardGroup>
    <CCardGroup className = "cols-1" >
      
      <CCard width={'100%'}>
        <CCardHeader>
          Price
        </CCardHeader>
        <CCardBody>
          <CChartLine
            width={'100%'}
            datasets={data.datasets}
            options={{
              tooltips: {
                enabled: true
              }
            }}
            labels={data.labels}
          />
        </CCardBody>
      </CCard>
    </CCardGroup>
    </>
  )
}

export default Charts
