import * as React from 'react';
import { styled, createTheme, ThemeProvider } from '@mui/material/styles';
import CssBaseline from '@mui/material/CssBaseline';
import MuiDrawer from '@mui/material/Drawer';
import Box from '@mui/material/Box';
import MuiAppBar, { AppBarProps as MuiAppBarProps } from '@mui/material/AppBar';
import Toolbar from '@mui/material/Toolbar';
import List from '@mui/material/List';
import Typography from '@mui/material/Typography';
import Divider from '@mui/material/Divider';
import IconButton from '@mui/material/IconButton';
import Badge from '@mui/material/Badge';
import Container from '@mui/material/Container';
import Grid from '@mui/material/Grid';
import MenuIcon from '@mui/icons-material/Menu';
import ChevronLeftIcon from '@mui/icons-material/ChevronLeft';
import NotificationsIcon from '@mui/icons-material/Notifications';
import { useSelector } from 'react-redux';
import { DataGrid, GridColDef, GridValueGetterParams } from '@mui/x-data-grid';
import { useEffect, useState } from 'react';
import axios from "axios";
import { Button } from '@mui/material';
import TextField from '@mui/material/TextField';
import FormGroup from '@mui/material/FormGroup';
import FormControlLabel from '@mui/material/FormControlLabel';
import Checkbox from '@mui/material/Checkbox';
import { useDispatch } from 'react-redux';
import { useNavigate  } from "react-router-dom";
import { setToken ,setResfreshToken} from '../stores/actions.js'

const drawerWidth: number = 240;

interface AppBarProps extends MuiAppBarProps {
  open?: boolean;
}

const AppBar = styled(MuiAppBar, {
  shouldForwardProp: (prop) => prop !== 'open',
})<AppBarProps>(({ theme, open }) => ({
  zIndex: theme.zIndex.drawer + 1,
  transition: theme.transitions.create(['width', 'margin'], {
    easing: theme.transitions.easing.sharp,
    duration: theme.transitions.duration.leavingScreen,
  }),
  ...(open && {
    marginLeft: drawerWidth,
    width: `calc(100% - ${drawerWidth}px)`,
    transition: theme.transitions.create(['width', 'margin'], {
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.enteringScreen,
    }),
  }),
}));

const Drawer = styled(MuiDrawer, { shouldForwardProp: (prop) => prop !== 'open' })(
  ({ theme, open }) => ({
    '& .MuiDrawer-paper': {
      position: 'relative',
      whiteSpace: 'nowrap',
      width: drawerWidth,
      transition: theme.transitions.create('width', {
        easing: theme.transitions.easing.sharp,
        duration: theme.transitions.duration.enteringScreen,
      }),
      boxSizing: 'border-box',
      ...(!open && {
        overflowX: 'hidden',
        transition: theme.transitions.create('width', {
          easing: theme.transitions.easing.sharp,
          duration: theme.transitions.duration.leavingScreen,
        }),
        width: theme.spacing(7),
        [theme.breakpoints.up('sm')]: {
          width: theme.spacing(9),
        },
      }),
    },
  }),
);

// TODO remove, this demo shouldn't need to reset the theme.
const defaultTheme = createTheme();

export default function Dashboard() {
  const token = useSelector((state: any) => state.token);
  const dispatch = useDispatch();
  const navigate = useNavigate();
  const refreshToken = useSelector((state: any) => state.refreshToken);
  const axiosInstance = axios.create({
    baseURL: 'http://localhost:5000/api/',
    headers:{
        Authorization : token,
        "Content-Type": "application/json"
    }
    });
    axiosInstance.interceptors.response.use((config)=>
    {
        return config
    }, 
    async (err) => 
    {
        const originalConfig = err.config;
        if (originalConfig.url !== "Identity/Login" && err.response){        
            // Access Token was expired
            if (err.response.status === 401 && !originalConfig._retry) {
                originalConfig._retry = true;
                try {
                    axios.get("http://localhost:5000/api/Identity/refreshToken", {
                      headers: {
                        'Authorization':  token
                      },
                      params:{ refreshToken: refreshToken}
                    }).then((rs)=>{
                      debugger
                      if(rs?.data?.token){
                        dispatch(setToken(rs?.data?.token));
                        dispatch(setResfreshToken(rs?.data?.refreshToken));
                        originalConfig.headers.Authorization = `Bearer ${rs?.data?.token.accessToken}`;
                      }else{
                        navigate('/');
                        localStorage.clear()
                      }
                    return axiosInstance(originalConfig);
                    });
                  } catch (_error) {
                    return Promise.reject(_error);
                  }
            }
            navigate('/');
        }
    })
  const [movie, setMovie] = useState<any>([]);
  const [movieFavorite, setMovieFavorite] = useState<any>([]);
  const [onlyFavoritesChecked, setOnlyFavoritesChecked] = useState<boolean>(false);
  
  const fetchData = async () => {
    try {
      let config = {
        headers: {
          'Authorization':  token
        }
      }
      axiosInstance.get('Movie/GetAll',config).then((response)=>{
        setMovie(response.data.movies);
      });

      
    } catch (error) {
      console.error('Error fetching data:', error);
    }
  };  
  useEffect(() => {
    fetchData();
    return () => {
      // Cleanup işlemleri buraya eklenebilir
    };
  }, []); 
  useEffect(()=>{
      setMovieFavorite(movie.filter((item:any)=> item.isMarked))
  },[onlyFavoritesChecked])
  const [open, setOpen] = React.useState(true);
  const toggleDrawer = () => {
    setOpen(!open);
  };

  const columns: GridColDef[] = [
    { field: 'name', headerName: 'Name', width: 300 },
    { field: 'title', headerName: 'Title', width: 300 },
    { field: 'description', headerName: 'Description', width: 300 },
    { field: 'isMarked', headerName: 'Favories', width: 150 },
    {
      field: 'actions',
      headerName: 'Actions',
      width: 150,
      renderCell: (params) => (
        <Button variant="contained" color="primary" onClick={() => handleFavoriteClick(params.row)}>
          {params.row.isMarked ? "Out of Favorite":"Add Favorite"}
        </Button>
      ),
    },
  ];
  const handleFavoriteClick = (data:any) => {
    let config = {
      headers: {
        'Authorization':  token
      }
    }
    axiosInstance.post('Movie/MarkMovie',{movieId : data.id},config).then((response)=>{
      fetchData()
    });
  };
  const handleSearch = (event:any) => {
    const { name, value } = event.target;
    console.log(`Input with name '${name}' changed to value: '${value}'`);
      let config = {
        headers: {
          'Authorization':  token
        }
      }
      axiosInstance.post('Movie/GetFilteredMovie',{filterInput : value},config).then((response)=>{
        console.log(response);
        setMovie(response.data.movies)
      });
  };
  const generateDefaultData =()=>{
    axiosInstance.post('Movie/GenerateRandomMovie',{count : 10},{
      headers: {
        'Authorization':  token
      }
    }).then((response)=>{
      console.log(response);
      fetchData()
    });
  }
  const handleOnlyFavoriteChange = (event:any) => {
    setOnlyFavoritesChecked(event.target.checked); // Checkbox değerini güncelle
  };
  return (
    <ThemeProvider theme={defaultTheme}>
      <Box sx={{ display: 'flex' }}>
        <CssBaseline />
        <AppBar position="absolute" open={open}>
          <Toolbar
            sx={{
              pr: '24px', // keep right padding when drawer closed
            }}
          >
            <IconButton
              edge="start"
              color="inherit"
              aria-label="open drawer"
              onClick={toggleDrawer}
              sx={{
                marginRight: '36px',
                ...(open && { display: 'none' }),
              }}
            >
              <MenuIcon />
            </IconButton>
            <Typography
              component="h1"
              variant="h6"
              color="inherit"
              noWrap
              sx={{ flexGrow: 1 }}
            >
              Dashboard
            </Typography>
            <IconButton color="inherit">
              <Badge badgeContent={4} color="secondary">
                <NotificationsIcon />
              </Badge>
            </IconButton>
          </Toolbar>
        </AppBar>
        <Drawer variant="permanent" open={open}>
          <Toolbar
            sx={{
              display: 'flex',
              alignItems: 'center',
              justifyContent: 'flex-end',
              px: [1],
            }}
          >
            <IconButton onClick={toggleDrawer}>
              <ChevronLeftIcon />
            </IconButton>
          </Toolbar>
          <Divider />
          <List component="nav">
            {/* {mainListItems} */}
            <Divider sx={{ my: 1 }} />
            {/* {secondaryListItems} */}
          </List>
        </Drawer>
        <Box
          component="main"
          sx={{
            backgroundColor: (theme) =>
              theme.palette.mode === 'light'
                ? theme.palette.grey[100]
                : theme.palette.grey[900],
            flexGrow: 1,
            height: '100vh',
            overflow: 'auto',
          }}
        >
          <Toolbar />
          <Container maxWidth="lg" sx={{ mt: 4, mb: 4 }}>
            <Grid container spacing={3}>
            <FormGroup>
            <FormControlLabel
              control={<Checkbox checked={onlyFavoritesChecked} onChange={handleOnlyFavoriteChange} />}
              label="Show Only my favorites"
            />
            </FormGroup>
            <Button variant="contained" color="primary" onClick={() => generateDefaultData()}>
              Generate Default Data
            </Button>
              <Grid item xs={12} md={12} lg={12}>
              <TextField id="standard-basic" name='search' label="Search by title" variant="standard" onChange={handleSearch}/>
                <div style={{ height: 400, width: '100%', marginTop:"25px" }}>
                  <DataGrid
                    rows={onlyFavoritesChecked ? movieFavorite  :movie}
                    columns={columns}
                    initialState={{
                      pagination: {
                        paginationModel: { page: 0, pageSize: 5 },
                      },
                    }}
                    select-none
                    pageSizeOptions={[5, 10]}
                  />
                </div>
              </Grid>
            </Grid>
          </Container>
        </Box>
      </Box>
    </ThemeProvider>
  );
}