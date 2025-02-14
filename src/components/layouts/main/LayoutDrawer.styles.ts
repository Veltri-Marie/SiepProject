import { styled } from "@mui/system";
import { Drawer, ListItemButton, ListItemIcon, ListItemText, Toolbar } from "@mui/material";

const drawerWidth = 260;

export const StyledDrawer = styled(Drawer)({
    width: drawerWidth,
    "& .MuiDrawer-paper": {
        width: drawerWidth,
        backgroundColor: "#2C3E50",
        color: "#FFF",
    },
});

export const StyledToolbar = styled(Toolbar)({
    justifyContent: "center",
    padding: 2,
});

export const StyledListItemButton = styled(ListItemButton)(() => ({
    "&.Mui-selected": {
        backgroundColor: "#f8a23a",
        color: "#fff",
    },
    "&:not(.Mui-selected)": {
        backgroundColor: "transparent",
        color: "#fff",
    },
    "&.Mui-selected:hover": {
        backgroundColor: "rgba(248,162,58,0.8)",
        color: "#fff",
    },
    "&:not(.Mui-selected):hover": {
        backgroundColor: "rgba(255,255,255,0.2)",
        color: "#fff",
    },
    transition: "background-color 0.3s ease, color 0.3s ease",
}));

export const StyledLogo = styled('img')({
    width: '70%',
    height: 'auto',
});

export const StyledListItemIcon = styled(ListItemIcon)<{ selected: boolean }>(({ selected }) => ({
    color: selected ? "#fff" : "#f8a23a",
    transition: "color 0.3s ease",
}));


export const StyledListItemText = styled(ListItemText)({
    // On peut ajouter des styles supplémentaires pour le texte si nécessaire
});
