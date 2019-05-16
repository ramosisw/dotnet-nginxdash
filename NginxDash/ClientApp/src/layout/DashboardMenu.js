import React from 'react'
import ListItemIcon from '@material-ui/core/ListItemIcon'
import ListItemText from '@material-ui/core/ListItemText'
import ListSubheader from '@material-ui/core/ListSubheader'
import DevicesIcon from '@material-ui/icons/Devices'
import DashboardIcon from '@material-ui/icons/Dashboard'
import PlaceIcon from '@material-ui/icons/Place'
import LinkListItem from './../components/LinkListItem'
import {config} from '../config'

export const mainListItems = (
    <div>
        <LinkListItem to={config.homePath + "/"} button>
            <ListItemIcon>
                <DashboardIcon />
            </ListItemIcon>
            <ListItemText primary="Dashboard" />
        </LinkListItem>
        <LinkListItem to={config.homePath + "/handlers"} button>
            <ListItemIcon>
                <DevicesIcon />
            </ListItemIcon>
            <ListItemText primary="Handlers" />
        </LinkListItem>
        <LinkListItem to={config.homePath + "/locations"} button>
            <ListItemIcon>
                <PlaceIcon />
            </ListItemIcon>
            <ListItemText primary="Locations" />
        </LinkListItem>
    </div>
);

export const secondaryListItems = (
    <div>
        <ListSubheader inset>Other options...</ListSubheader>
    </div>
);