import React from 'react'
import CIcon from '@coreui/icons-react'

const _nav =  {
  Manager: [
    {
      _tag: 'CSidebarNavItem',
      name: 'Dashboard',
      to: '/dashboard',
      icon: <CIcon name="cil-speedometer" customClasses="c-sidebar-nav-icon"/>,
      badge: {
        color: 'info',
        text: 'NEW',
      }
    },
    {
      _tag: 'CSidebarNavTitle',
      _children: ['Reports']
    },
    {
      _tag: 'CSidebarNavItem',
      name: 'Daily PnL',
      to: '/dailypnl',
      icon: <CIcon name="cil-chart-line" customClasses="c-sidebar-nav-icon"/>,
    },
    {
      _tag: 'CSidebarNavItem',
      name: 'PnL YTD',
      to: '/pnlytd',
      icon: <CIcon name="cil-chart-line" customClasses="c-sidebar-nav-icon"/>,
    },
    {
      _tag: 'CSidebarNavItem',
      name: 'PnL LTD',
      to: '/pnlltd',
      icon: <CIcon name="cil-chart-line" customClasses="c-sidebar-nav-icon"/>,
    },
    {
      _tag: 'CSidebarNavItem',
      name: 'Drawdown YTD',
      to: '/drawdown',
      icon: <CIcon name="cil-chart-line" customClasses="c-sidebar-nav-icon"/>,
    },
    {
      _tag: 'CSidebarNavItem',
      name: 'Position',
      to: '/position',
      icon: <CIcon name="cil-chart-line" customClasses="c-sidebar-nav-icon"/>,
    },
    {
      _tag: 'CSidebarNavItem',
      name: 'Price',
      to: '/price',
      icon: <CIcon name="cil-chart-line" customClasses="c-sidebar-nav-icon"/>,
    },
  ],
  Developer: [
    {
      _tag: 'CSidebarNavItem',
      name: 'Dashboard',
      to: '/dashboard',
      icon: <CIcon name="cil-speedometer" customClasses="c-sidebar-nav-icon"/>,
      badge: {
        color: 'info',
        text: 'NEW',
      }
    },
  ],
  Trader: [
    {
      _tag: 'CSidebarNavItem',
      name: 'Dashboard',
      to: '/dashboard',
      icon: <CIcon name="cil-speedometer" customClasses="c-sidebar-nav-icon"/>,
      badge: {
        color: 'info',
        text: 'NEW',
      }
    },
    {
      _tag: 'CSidebarNavTitle',
      _children: ['Reports']
    },
    {
      _tag: 'CSidebarNavItem',
      name: 'Daily PnL',
      to: '/dailypnl',
      icon: <CIcon name="cil-chart-line" customClasses="c-sidebar-nav-icon"/>,
    },
  ]
  
}

export default _nav
