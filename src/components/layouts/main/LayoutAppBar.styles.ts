import { styled } from "@mui/system";
import { AppBar, Avatar, IconButton, Toolbar, Typography } from "@mui/material";

const appbarHeight = 64;

export const StyledAppBar = styled(AppBar)({
    width: `calc(100% - 260px)`,
    marginLeft: '260px',
    backgroundColor: "#2C3E50",
    zIndex: 1300,
    height: `${appbarHeight}px`,
});

export const StyledToolbar = styled(Toolbar)({
    display: 'flex',
    justifyContent: 'space-between',
});

export const StyledTypography = styled(Typography)({
    flexGrow: 1,
});

export const StyledIconButton = styled(IconButton)({

});

export const StyledAvatar = styled(Avatar)({

});