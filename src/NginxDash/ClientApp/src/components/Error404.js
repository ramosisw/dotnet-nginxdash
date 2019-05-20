import React, {Component} from "react";
import Paper from "@material-ui/core/Paper/Paper";
import Typography from "@material-ui/core/Typography/Typography";
import withStyles from "@material-ui/core/es/styles/withStyles";


const styles = theme => ({
    root: {
        ...theme.mixins.gutters(),
        paddingTop: theme.spacing.unit * 2,
        paddingBottom: theme.spacing.unit * 2,
    },
});

class Error404 extends Component {
    /**
     * Renders
     */
    render() {
        const {classes, message} = this.props;

        return (
            <div>
                <Paper className={classes.root} elevation={1}>
                    <Typography variant="h5" component="h3">
                        Error URL Request not found
                    </Typography>
                    <Typography component="p">
                        {message}
                    </Typography>
                </Paper>
            </div>
        );
    }
}

export default withStyles(styles)(Error404);
