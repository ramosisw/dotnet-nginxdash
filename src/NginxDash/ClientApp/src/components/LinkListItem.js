import React from 'react'
import PropTypes from 'prop-types'
import { withRouter } from 'react-router-dom'
import ListItem from '@material-ui/core/ListItem'

const LinkListItem = (props) => {
  const {
    history,
    location,
    match,
    staticContext,
    to,
    onClick,
    // ⬆ filtering out props that 'ListItem' doesn’t know what to do with.
    ...rest
  } = props;
  return (
    <ListItem
      selected={location.pathname === to}
      {...rest} // 'children' is just another prop!
      onClick={(event) => {
        onClick && onClick(event)
        history.push(to)
      }}
    />
  )
}

LinkListItem.propTypes = {
  to: PropTypes.string.isRequired,
  children: PropTypes.node.isRequired
}

export default withRouter(LinkListItem)