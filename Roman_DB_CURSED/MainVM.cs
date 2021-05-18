using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
using Roman_DB_CURSED.AddEditEntity;

namespace Roman_DB_CURSED
{
    public class MainVM
    {
        private readonly CalcEntities db = new CalcEntities();

        public MainVM()
        {
            db = new CalcEntities();
            foreach (var VARIABLE in Storages)
            {
                Trace.WriteLine($"{VARIABLE.StorageId} {VARIABLE.StorageName}");
            }
        }

        #region properties

        public BindingList<storage> Storages
        {
            get
            {
                db.storage.Load();
                return db.storage.Local.ToBindingList();
            }
        }

        public BindingList<nom> Noms
        {
            get
            {
                db.nom.Load();
                return db.nom.Local.ToBindingList();
            }
        }

        public BindingList<resspec> Resspecs
        {
            get
            {
                db.resspec.Load();
                return db.resspec.Local.ToBindingList();
            }
        }

        public BindingList<resspecnoms> Resspecnoms
        {
            get
            {
                db.resspecnoms.Load();
                return db.resspecnoms.Local.ToBindingList();
            }
        }

        public BindingList<subdivision> Subdivisions
        {
            get
            {
                db.subdivision.Load();
                return db.subdivision.Local.ToBindingList();
            }
        }

        public BindingList<storagecontains> Storagecontains
        {
            get
            {
                db.storagecontains.Load();
                return db.storagecontains.Local.ToBindingList();
            }
        }

        public BindingList<measure> Measures
        {
            get
            {
                db.measure.Load();
                return db.measure.Local.ToBindingList();
            }
        }

        public BindingList<nomtype> Nomtypes
        {
            get
            {
                db.nomtype.Load();
                return db.nomtype.Local.ToBindingList();
            }
        }

        public BindingList<order> Orders
        {
            get
            {
                db.order.Load();
                return db.order.Local.ToBindingList();
            }
        }

        public BindingList<orderstatus> Orderstatus
        {
            get
            {
                db.orderstatus.Load();
                return db.orderstatus.Local.ToBindingList();
            }
        }

        public BindingList<prodstage> Prodstages
        {
            get
            {
                db.prodstage.Load();
                return db.prodstage.Local.ToBindingList();
            }
        }

        public BindingList<techmap> Techmaps
        {
            get
            {
                db.techmap.Load();
                return db.techmap.Local.ToBindingList();
            }
        }

        #endregion

        #region Commands

        #region AddCommands

        private RelayCommand addMeasure;
        public RelayCommand AddMeasure
        {
            get
            {
                return addMeasure ??
                       (addMeasure = new RelayCommand(o =>
                       {
                           MeasureEdit measureEdit = new MeasureEdit(new measure());
                           if (measureEdit.ShowDialog() == true)
                           {
                               measure measure = measureEdit.Measure;
                               db.measure.Add(measure);
                               db.SaveChanges();
                           }
                       }));
            }
        }


        private RelayCommand addNom;
        public RelayCommand AddNom
        {
            get
            {
                return addNom ??
                       (addNom = new RelayCommand(o =>
                       {
                           NomEdit nomEdit = new NomEdit(new nom(), db);
                           if (nomEdit.ShowDialog() == true)
                           {
                               nom nom = nomEdit.Nom;
                               db.nom.Add(nom);
                               db.SaveChanges();
                           }
                       }));
            }
        }


        private RelayCommand addNomType;
        public RelayCommand AddNomType
        {
            get
            {
                return addNomType ??
                       (addNomType = new RelayCommand(o =>
                       {
                           NomTypeEdit nomTypeEdit = new NomTypeEdit(new nomtype());
                           if (nomTypeEdit.ShowDialog() == true)
                           {
                               nomtype nomtype = nomTypeEdit.Nomtype;
                               db.nomtype.Add(nomtype);
                               db.SaveChanges();
                           }
                       }));
            }
        }


        private RelayCommand addOrder;
        public RelayCommand AddOrder
        {
            get
            {
                return addOrder ??
                       (addOrder = new RelayCommand(o =>
                       {
                           OrderEdit orderEdit = new OrderEdit(new order(),db);
                           if (orderEdit.ShowDialog() == true)
                           {
                               order order = orderEdit.Order;
                               db.order.Add(order);
                               db.SaveChanges();
                           }
                       }));
            }
        }


        private RelayCommand addOrderStatus;
        public RelayCommand AddOrderStatus
        {
            get
            {
                return addOrderStatus ??
                       (addOrderStatus = new RelayCommand(o =>
                       {
                           OrderStatusEdit orderStatusEdit = new OrderStatusEdit(new orderstatus());
                           if (orderStatusEdit.ShowDialog() == true)
                           {
                               orderstatus orderstatus = orderStatusEdit.OrderStatus;
                               db.orderstatus.Add(orderstatus);
                               db.SaveChanges();
                           }
                       }));
            }
        }


        private RelayCommand addResSpec;
        public RelayCommand AddResSpec
        {
            get
            {
                return addResSpec ??
                       (addResSpec = new RelayCommand(o =>
                       {
                           ResSpecEdit resSpecEdit = new ResSpecEdit(new resspec(), db);
                           if (resSpecEdit.ShowDialog() == true)
                           {
                               resspec resspec = resSpecEdit.Resspec;
                               db.resspec.Add(resspec);
                               db.SaveChanges();
                           }
                       }));
            }
        }


        private RelayCommand addStorage;
        public RelayCommand AddStorage
        {
            get
            {
                return addStorage ??
                       (addStorage = new RelayCommand(o =>
                       {
                           StorageEdit storageEdit = new StorageEdit(new storage());
                           if (storageEdit.ShowDialog() == true)
                           {
                               storage storage = storageEdit.Storage;
                               db.storage.Add(storage);
                               db.SaveChanges();
                           }
                       }));
            }
        }


        private RelayCommand addSubdivision;
        public RelayCommand AddSubdivision
        {
            get
            {
                return addSubdivision ??
                       (addSubdivision = new RelayCommand(o =>
                       {
                           SubdivisionEdit subdivisionEdit = new SubdivisionEdit(new subdivision());
                           if (subdivisionEdit.ShowDialog() == true)
                           {
                               subdivision subdivision = subdivisionEdit.Subdivision;
                               db.subdivision.Add(subdivision);
                               db.SaveChanges();
                           }
                       }));
            }
        }


        private RelayCommand addTechMap;
        public RelayCommand AddTechMap
        {
            get
            {
                return addTechMap ??
                       (addTechMap = new RelayCommand(o =>
                       {
                           TechMapEdit techMapEdit = new TechMapEdit(new techmap());
                           if (techMapEdit.ShowDialog() == true)
                           {
                               techmap techmap = techMapEdit.Techmap;
                               db.techmap.Add(techmap);
                               db.SaveChanges();
                           }
                       }));
            }
        }


        #endregion


        #endregion
    }
}