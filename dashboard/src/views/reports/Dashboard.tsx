import React, { useEffect, useState } from 'react'
import {
  CCard,
  CCardBody,
  CCardGroup,
  CCardHeader
} from '@coreui/react'
import {
  CChartLine,
} from '@coreui/react-chartjs'
import { getTimeSeries } from '../../services/reports';
import moment from 'moment';
// import { DocsLink } from 'src/reusable'

const Charts = () => {
  const [data, setData] = useState<any>({
    datasets: [],
    labels: [],
  })

  useEffect(() => {
    const fetchData = async () => {
      const result = await getTimeSeries();

      const chartData: any = {
        datasets: [{
          data: [],
          label: `Value`,
          backgroundColor: 'rgba(75,192,192,0.4)',
          borderColor: 'rgba(75,192,192,1)',
          borderCapStyle: 'butt',
          borderDash: [],
          borderDashOffset: 0.0,
          borderJoinStyle: 'miter',
          pointBorderColor: 'rgba(75,192,192,1)',
          pointBackgroundColor: '#fff',
          pointBorderWidth: 1,
          pointHoverRadius: 5,
          pointHoverBackgroundColor: 'rgba(75,192,192,1)',
          pointHoverBorderColor: 'rgba(220,220,220,1)',
          pointHoverBorderWidth: 2,
          pointRadius: 1,
          pointHitRadius: 10,
        }, {
          data: [],
          label: `Rolling Value`,
          backgroundColor: 'rgba(255,99,132,0.2',
          borderColor: 'rgba(255,99,132,1)',
          borderCapStyle: 'butt',
          borderDash: [],
          borderDashOffset: 0.0,
          borderJoinStyle: 'miter',
          pointBorderColor: 'rgba(255,99,132,1)',
          pointBackgroundColor: '#fff',
          pointBorderWidth: 1,
          pointHoverRadius: 5,
          pointHoverBackgroundColor: 'rgba(255,99,132,1)',
          pointHoverBorderColor: 'rgba(220,220,220,1)',
          pointHoverBorderWidth: 2,
          pointRadius: 1,
          pointHitRadius: 10,
        }],
        labels:[],
      };
      for (const row of result.rows as Array<any>) {
        chartData.labels.push(moment(row.date).format('MMM YY'));
        chartData.datasets[0].data.push(row.value);
        chartData.datasets[1].data.push(row.rollingValue);
      }
 
      setData(chartData);
    };
 
    fetchData();
  }, []);

  return (
    <CCardGroup className = "cols-1" >
      <CCard width={'100%'}>
        <CCardHeader>
          Price Stitching Smoothing
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
  )
}

export default Charts
