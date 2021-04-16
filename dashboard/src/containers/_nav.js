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
      icon: 'cil-drop',
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
  ]
  
}

export default _nav
